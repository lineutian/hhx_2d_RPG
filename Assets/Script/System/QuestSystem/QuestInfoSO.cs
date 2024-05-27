using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "QuestInfoSO",menuName = "ScriptableObjects/QuestInfoSO",order = 1)]
public class QuestInfoSO : SerializedScriptableObject
{
    [field:SerializeField]public string id { get; private set; }

    [Header("General<常规设置>")]
    //任务名称
    public string displayName;
    //任务整体描述
    public string descriptio;
    

    [Header("Requirements<任务需求>")] 
    //任务需求等级
    public int levelReuirements;
    //任务先决条件
    public QuestInfoSO[] questPrerequisites;

    [Header("Steps<任务步骤>")] 
    //步骤
    public GameObject[] questStepPrefabs;

    [Header("Rewards<奖励>")] 
    //奖励金币
    public int goldReward;
    //奖励经验
    public int experienceReward;
    //奖励道具
    public Dictionary<ItemUI, int> ItemReward=new Dictionary<ItemUI, int>();

    private void OnValidate()
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
