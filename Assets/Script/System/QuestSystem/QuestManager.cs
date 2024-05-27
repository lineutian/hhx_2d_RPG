using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
   private Dictionary<string, Quest> questMap;

   public Dictionary<string, Quest> QuestMap => questMap;

   private int currentPlayerLevel;

   protected override void Awake()
   {
      base.Awake();
      questMap=CreateQuestMap();
   }

   //激活时订阅事件
   private void OnEnable()
   {
      GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
      GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
      GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;

      GameEventsManager.instance.playerEvents.onLevelChange += PlayerLevelChange;
   }
   //停用时取消订阅
   private void OnDisable()
   {
      GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
      GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
      GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;
      
      GameEventsManager.instance.playerEvents.onLevelChange -= PlayerLevelChange;
   }

   private void Start()
   {
      foreach (Quest quest in questMap.Values)
      {
         GameEventsManager.instance.questEvents.QuestStateChange(quest);
      }
   }

   private void PlayerLevelChange(int lv)
   {
      currentPlayerLevel = lv;
      Debug.Log(lv);
   }

   private bool CheckRequirementsMet(Quest quest)
   {
      bool meetsRequirements = !(currentPlayerLevel<quest.info.levelReuirements);

      foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
      {
         if (GetQuestById(prerequisiteQuestInfo.id).state!=QuestState.FINISHED)
         {
            meetsRequirements = false;
         }
      }
      return meetsRequirements;
   }

   private void Update()
   {
      foreach (Quest quest in questMap.Values)
      {
         if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
         {
            ChangeQuestState(quest.info.id,QuestState.CAN_START);
         }
      }
   }
   

   private void ChangeQuestState(string id, QuestState state)
   {
      Quest quest = GetQuestById(id);
      quest.state = state;
      GameEventsManager.instance.questEvents.QuestStateChange(quest);
      QuestInfoController.Instance.RefreshhUI();
   }

   private void StartQuest(string id)
   {
      Quest quest = GetQuestById(id);
      quest.InstantiateCurrentQuestStep(this.transform);
      ChangeQuestState(quest.info.id,QuestState.IN_PROGRESS);
      Debug.Log("开始任务"+id);
   }
   
   private void AdvanceQuest(string id)
   {
      Quest quest = GetQuestById(id);
      quest.MoveToNextStep();
      if (quest.CurrentStepExists())
      {
         quest.InstantiateCurrentQuestStep(this.transform);
      }
      else
      {
         ChangeQuestState(quest.info.id,QuestState.CAN_FINISH);
      }
      Debug.Log("任务进展"+id);
   }
   
   private void FinishQuest(string id)
   {
      Quest quest = GetQuestById(id);
      ClaimRewards(quest);
      ChangeQuestState(id,QuestState.FINISHED);
      Debug.Log("完成任务"+id);
   }

   private void ClaimRewards(Quest quest)
   {
      GameEventsManager.instance.playerEvents.GetExp(quest.info.experienceReward);
      Player.Instance.playerData.GetCoins(quest.info.goldReward);
      foreach ( var itemReward in quest.info.ItemReward)
      {
         Player.Instance.playerData.AddItemToInventory(itemReward.Key.ItemID,itemReward.Value);
      }
   }
   private Dictionary<string, Quest> CreateQuestMap()
   {
      //加载Resources里的QuestInfoSO
      QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quest");
      Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
      foreach (QuestInfoSO questInfo in allQuests)
      {
         if (idToQuestMap.ContainsKey(questInfo.id))
         {
            Debug.LogWarning("创建的id:"+questInfo.id+"已经在questMap里存在了");
         }
         idToQuestMap.Add(questInfo.id,new Quest(questInfo));
         Debug.Log(questInfo.id);
      }

      return idToQuestMap;
   }
   
   //通过id获取到任务
   public Quest GetQuestById(string id)
   {
      Quest quest = questMap[id];
      if (quest==null)
      {
         Debug.LogError("ID:"+id+"不在questMap里面");
      }

      return quest;
   }
}
