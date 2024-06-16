using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipMentSetSO",menuName = "自定义/武器/武器套装",order = 1)]
public class EquipMentSet: SerializedScriptableObject
{
    [Tooltip("套装ID"),Label("套装ID")]
    public int EquipSuitId;
    [Tooltip("套装ID"),Label("套装名称")]
    public string EquipSuitName;
    [Label("套装描述")]
    public string EquipSuitDesc;
    [Label("套装所需要的件数")]
    public int EquipSuitCount;
    [Label("套装效果的实例")]
    public GameObject EquipSuitModel;
}
