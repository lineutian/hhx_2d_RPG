using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SaveData
{
    public int playerHP; 
    public Vector3 playerPosition;
    public Dictionary<int, int> ItemList=new Dictionary<int, int>();
    public PlayerData Data=new PlayerData();
}
