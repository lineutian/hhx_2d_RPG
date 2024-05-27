using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SaveData
{
    public int playerHP; 
    public Vector3 playerPosition;
    public int EQUIPid;
    public Dictionary<ItemType, List<ItemUI>> ItemTpyeLib = new Dictionary<ItemType, List<ItemUI>>();
    public Dictionary<string, ItemUI> ItemIndexLib = new Dictionary<string, ItemUI>();
    public Dictionary<int, ItemUI> ItemIDLib = new Dictionary<int, ItemUI>();
    public Dictionary<int,EquipData>  EquipdataLib = new Dictionary<int, EquipData>();

    #region 玩家数据

    public PlayerData Data;
    public CharacterData CharacterData;
    public int playerLevel;
    public int currentExp;
    public int nextLevelExp;
    public int coins;
    public int currentHealth;
    public int playerMaxHealth;
    public int playerAtk;
    public int playerDef;
    public Dictionary<int, int> Inventory=new Dictionary<int, int>();
    public Dictionary<int, int> Equiptory = new Dictionary<int, int>();
    #endregion
}
