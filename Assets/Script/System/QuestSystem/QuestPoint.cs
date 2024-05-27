using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest<任务>")] 
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config<配置>")] 
    [SerializeField] private bool startPoint;
    [SerializeField] private bool finishPoint;
    //玩家是否靠近
    private bool PlayerIsNear = false;

    private string questId;

    private QuestState currentQuestState;

    private QuestIcon questIcon;

    private QuestText questText;

    private void Awake()
    {
        questId = questInfoForPoint.id;
        questIcon = GetComponentInChildren<QuestIcon>();
        questText = GetComponentInChildren<QuestText>();
        questText.gameObject.SetActive(false);
    }

    private void Start()
    {
        GetComponent<UITip>().Add("对话",this.transform,SubmitPressed);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
    }

    private void QuestStateChange(Quest quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log(currentQuestState);
            questIcon.SetState(currentQuestState,startPoint,finishPoint);
            questText.SetState(currentQuestState,startPoint,finishPoint,quest);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerIsNear = true;
            if (questText.IsQuestText)
            {
                questText.gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsNear = false;
            questText.gameObject.SetActive(false);
        }
    }

    private void SubmitPressed()
    {
        if (!PlayerIsNear)
        {
            return;
        }
            
            
        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.instance.questEvents.StartQuest(questId);
        }
        else if(currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(questId);
        }
    }
    
}
