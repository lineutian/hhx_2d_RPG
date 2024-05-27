using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO",menuName = "ScriptableObjects/EnemyDataSO",order = 1)]
public class EnemyDataSO : SerializedScriptableObject
{
    public int id;
    
    [Header("setting<设定>")]
    //怪物名字
    [field:SerializeField]public string enemyName;

    [Header("data<数据>")] 
    public int Atk;

    public int Def;
    [Header("trophy<掉落物品>")] 
    public int Coin;
    public int Exp;
    public Dictionary<ItemUI,int> trophyGroup;

}
