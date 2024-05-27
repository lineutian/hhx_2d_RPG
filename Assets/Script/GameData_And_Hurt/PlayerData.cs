using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Unity.Mathematics;
using UnityEngine;
using static myExpected;

public class PlayerData : CharacterData
{
    #region 字段
    /// <summary>
    /// 装备栏
    /// </summary>
    public Dictionary<int, int> Equiptory=new Dictionary<int, int>();

    public Dictionary<int, int> Inventory = new Dictionary<int, int>();

    public int Level { get; private set; } = 1;
    public int CurrentExp { get; private set; }

    public int NextLevelNeedExp { get; private set; } = 100;

    public int Coins { get; private set; } = 0;
    

    #endregion
    

    public PlayerData()
    {
        
    }

    public void PlayerAddEvent()
    {
        GameEventsManager.instance.playerEvents.onGetExp += GetExp;
        GameEventsManager.instance.playerEvents.onHpChange+=changeHpEvnet;
    }

    public void PlayerMoveEvent()
    {
        GameEventsManager.instance.playerEvents.onGetExp -=GetExp;
        GameEventsManager.instance.playerEvents.onHpChange-=changeHpEvnet;
    }
    

    public void changeHpEvnet(int _amout)
    {
        xuetiao.Instance.updatehp(CurrentHealth,MaxHealth);
        string _text = _amout > 0 ? "<color=green>+" + _amout +"</color>": "<color=red>"+_amout.ToString()+"</color>";
        MSGcontroller.Instance.addMsg($"你的生命值{_text}");
        if (CurrentHealth<=0)
        {
            EventCenter.Instance.EventTrigger<Player>("Player_die",ObjectManager.Player.GetComponent<Player>());
        }
    }
    

    /// <summary>
    /// 对背包内道具操作
    /// </summary>
    /// <param name="id">物品id</param>
    /// <param name="amout">数量</param>
    public void AddItemToInventory(int id,int amount = 1)
    {
        if (amount > 0)
        {
            MSGcontroller.Instance.addMsg($"玩家获得{amount}个{ItemController.Instance.GetItemFormID(id).Index}");
            if (!Inventory.ContainsKey(id)) Inventory.Add(id, amount);
            else Inventory[id] += amount;
        }
        else
        {
            if (Inventory.ContainsKey(id))
                if (Inventory[id] >= Mathf.Abs(amount))
                {
                    Inventory[id] += amount;
                }
                else
                {
                    if (Equiptory.ContainsValue(id))
                    {
                        Debug.Log("装备目前无法丢弃");
                    }
                    else
                    {
                        Inventory.Remove(id);
                        Debug.Log("丢弃物品成功");
                    }
                }
            else
            {
                Debug.Log("不存在该物品");
            }
        }
        ItemController.Instance.RefreshhUI(Inventory);//更新Ui
    }
    public void AddEquipToEquiptory(int id)
    {
        int EquipTypeId=0;
        EquipType i = equipController.Instance.GetEquipFormID(id).EquipType;
        switch (i)
        {
            case EquipType.内裤:
                EquipTypeId = 0;
                break;
            case EquipType.鞋子:
                EquipTypeId = 1;
                break;
            case EquipType.衣服:
                EquipTypeId = 2;
                break;
            case EquipType.裤子:
                EquipTypeId = 3;
                break;
            case EquipType.帽子:
                EquipTypeId = 4;
                break;
            case EquipType.武器:
                EquipTypeId = 5;
                break;
        }
        if (!Equiptory.ContainsKey(EquipTypeId))
        {
            Equiptory.Add(EquipTypeId,id);
            UPdate();
        }
        else
        {
            Equiptory[EquipTypeId] = id;
            UPdate();
        }
    }

    public void UPdate()
    {
        int hp=MaxHealth;
        ExtraHp = 0;
        ExtraAtk = 0;
        ExtraDef = 0;
        foreach (var i in Equiptory)
        {
            equip equip = equipController.Instance.GetEquipFormID(i.Value);
            ExtraHp += equip.EquipData.Hp;
            ExtraAtk += equip.EquipData.Atk;
            ExtraDef += equip.EquipData.Ftk;
            if (equip.EquipType == EquipType.武器)
            {
                Player.Instance.gameObject.GetComponent<NewBehaviourScript>().ATKPefUPDATE(((Weapon)equip).weaponatk);
            }
        }
        UIController.Instance.sxgx();
        currentHealth=currentHealth/hp*MaxHealth;
        xuetiao.Instance.updatehp(CurrentHealth,MaxHealth);
        GameEventsManager.instance.playerEvents.GetExp(0);
        GetCoins(0);
        LevelUp(0);
        Debug.Log(Atk);
    }

    public void GetExp(int exp)
    {
        CurrentExp += exp;
        MSGcontroller.Instance.addMsg($"获得{exp}经验值");
        levelUp:
        if (CurrentExp>=NextLevelNeedExp)
        {
            CurrentExp -= NextLevelNeedExp;
            LevelUp(1);
            goto levelUp;
        }
    }

    public void LevelUp(int num)
    {
        if (num<0&&Mathf.Abs(num)>Level)
        {
            setAddMaxHp(-(Level-1)*100);
            Level = 1;
            NextLevelNeedExp = 100;
            Debug.Log($"当前等级：{Level.ToString()}");
        }
        else
        {
            Level += num;
            NextLevelNeedExp = Level * 100;
            setAddMaxHp(num*100);
            GameEventsManager.instance.playerEvents.LevelChange(Level);
            Debug.Log($"当前等级：{Level.ToString()}");
        }
        
    }

    public void GetCoins(int _num)
    {
        if (Coins<Math.Abs(_num)  &&  _num<0)
        {
            return;
        }
        Coins += _num;
        MSGcontroller.Instance.addMsg($"获得金币{_num}");
        GameEventsManager.instance.playerEvents.CoinChange(_num);
    }
    
    
    #region 存档

    public void locaData(SaveData saveData)
    {
        Level=saveData.playerLevel;
        CurrentExp=saveData.currentExp;
        NextLevelNeedExp = saveData.nextLevelExp;
        Coins=saveData.coins;
        currentHealth=saveData.currentHealth;
        maxHealth=saveData.playerMaxHealth;
        atk=saveData.playerAtk;
        def=saveData.playerDef;
        Inventory.Clear();
        Equiptory.Clear();
        DictionaryCopy(Inventory, saveData.Inventory);
        DictionaryCopy(Equiptory, saveData.Equiptory);
        ItemController.Instance.RefreshhUI(Inventory);
        UPdate();
        //Debug.Log("存档读取完成");
    }

    public void saveData(SaveData saveData)
    {
        saveData.playerLevel = Level;
        saveData.currentExp = CurrentExp;
        saveData.nextLevelExp = NextLevelNeedExp;
        saveData.coins = Coins;
        saveData.currentHealth = currentHealth;
        saveData.playerMaxHealth = maxHealth;
        saveData.playerAtk = atk;
        saveData.playerDef = def;
        DictionaryCopy(saveData.Inventory, Inventory);
        DictionaryCopy(saveData.Equiptory, Equiptory);
    }
    

    #endregion
}
