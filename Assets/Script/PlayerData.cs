using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : CharacterData
{
    /// <summary>
    /// 装备栏
    /// </summary>
    public Dictionary<EquipType, int> Equiptory;
    public Dictionary<int,int> Inventory;
    public PlayerData(){}

    public PlayerData(String _PLAYER_NAME_KEY)
    {
        Inventory = new Dictionary<int, int>();
        Equiptory = new Dictionary<EquipType, int>();
    }

    public override void changHp(int _amout)
    {
        base.changHp(_amout);
        xuetiao.Instance.updatehp(CurrentHealth,MaxHealth);
    }

    public void AddItemToInventory(int id,int amount = 1)
    {
        if (amount > 0)
        {
            if (!Inventory.ContainsKey(id)) Inventory.Add(id, amount);
            else Inventory[id] += amount;
        }
        else
        {
            if (Inventory.ContainsKey(id))
                if (Inventory[id] > Mathf.Abs(amount))
                {
                    Inventory[id] += amount;
                }
                else
                {
                    Debug.Log("物品不足");
                }
            else
            {
                Debug.Log("不存在该物品");
            }
        }
        ItemController.Instance.RefreshhUI(Inventory);//更新Ui
    }
}
