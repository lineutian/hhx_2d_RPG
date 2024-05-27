using System.Collections.Generic;
using UnityEngine;
using static LanguageController;

public class player_Data
{
    public string Name;
    public int Money { get; private set; }
    public int Player_LV;
    public int CurrentXP { get; private set; }
    public int NeedXP { get; private set; }
    public int Hp;
    public int Atk;
    public int Ftk;
    public int T_Hp { get; private set; }
    public int T_Atk { get; private set; }
    public int T_Ftk { get; private set; }

    public Dictionary<int,int> Inventory;//物品栏
    public Dictionary<string,bool> Achievement;//成就
    public Dictionary<EquipType, int> Equiptory;
    private Character data;
    private NewBehaviourScript data_1;
    public player_Data() { }
    public player_Data(string name)
    {
        T_Hp = Hp = 20;
        Name = name;
        Money = 100;
        Player_LV = 1;
        CurrentXP = 0;
        NeedXP = (Player_LV* Player_LV * 10 + 50);
        Inventory = new Dictionary<int, int>();
        Achievement= new Dictionary<string, bool>();
        Equiptory = new Dictionary<EquipType, int>();
        data=ObjectManager.Player.GetComponent<Character>();
        data_1=ObjectManager.Player.GetComponent<NewBehaviourScript>();
    }
    
    public bool ChangeMoney(int amount)//金钱变动
    {
        if (amount >= 0)
        {
            Money += amount;
            MSGcontroller.Instance.addMsg(System.String.Format(GetLocalT("MSG_Getmoney"),$"<color=yellow>{amount}</color>"));
        }
        else
        {
            if (Mathf.Abs(amount) > Money) return false;//mathf.abs绝对值
            Money += amount;
        }

        return true;
    }
    public void GetXP(int amount)
    {
        CurrentXP += amount;
        RaCal://标签RaCal处
        if (CurrentXP >= NeedXP)
        {
            CurrentXP -= NeedXP;
            Player_LV++;
            NeedXP = (Player_LV * Player_LV * 10 + 50);
            MSGcontroller.Instance.addMsg(System.String.Format(GetLocalT("MSG_Player_Lv_Up"),$"<color=yellow>{Player_LV}</color>"));
            goto RaCal;//回到标签RaCal处，再执行
        }
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

    public void AddEquipToEquiptory(int id)
    {
        EquipType i = equipController.Instance.GetEquipFormID(id).EquipType;
        if (!Equiptory.ContainsKey(i))
        {
            Equiptory.Add(i,id);
            UPdate();
        }
        else
        {
            Equiptory[i] = id;
            UPdate();
        }
    }

    public void UPdate()
    {
        T_Hp = Hp;
        T_Atk = Atk;
        T_Ftk = Ftk;
        foreach (var i in Equiptory)
        {
            equip equip = equipController.Instance.GetEquipFormID(i.Value);
            T_Hp += equip.EquipData.Hp;
            T_Atk += equip.EquipData.Atk;
            T_Ftk += equip.EquipData.Ftk;
            if (equip.EquipType == EquipType.武器)
            {
                data_1.ATKPefUPDATE(equip.EquipGameObject);
            }
        }
        UIController.Instance.sxgx();
        xuetiao.Instance.update(T_Hp);
    }
}