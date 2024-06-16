using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO",menuName = "ScriptableObjects/DialogInfoSO",order = 1)]
public class dialogInfoSO : SerializedScriptableObject
{
    [field:SerializeField]public string id { get; private set; }

    [Header("交互<Interaction>")] 
    public bool hasInteraction;

    public InteractionType interactionType;

    [Header("对话<Dialog>")] 
    public string greeting;
    [TextArea]public string[] npcDialogues;
    [TextArea]public string[] playerDialogues;
    /// <summary>
    /// 对话最后要执行的方法
    /// </summary>
    public Action Call;
}

