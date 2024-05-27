using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipController : Singleton<equipController>
{
    public static int id=10000;
    public Dictionary<int, equip> EquipIDLib = new Dictionary<int, equip>();
    /// <summary>
    /// 以id为模板创建一件随机的装备
    /// </summary>
    /// <param name="ID">以ID为模板</param>
    public void generate(int ID)
    {
        equip equip=GetEquipFormID(ID);
        if(equip.Type!=ItemType.装备)return;
        equip Newequip = ScriptableObject.Instantiate(equip);
        Newequip.ItemID = id;
        Newequip.ItemTypeID = ID;
        Newequip.Icon = equip.Icon;
        Newequip.Index = equip.Index;
        Newequip.Quality = equip.Quality;
        Newequip.Type = equip.Type;
        Newequip.DescribeIndex = equip.DescribeIndex;
        Newequip.IsStack = equip.IsStack;
        Newequip.IsUse = equip.IsUse;
        Newequip.EquipType = equip.EquipType;
        Newequip.EquipData.Atk = Random.Range(10, 20);
        Newequip.EquipData.Ftk = Random.Range(10, 20);
        Newequip.EquipData.Hp = Random.Range(20, 40);
        Newequip.EquipData.ID = Newequip.ItemTypeID;
        id++;
        Debug.Log("ATK:"+Newequip.EquipData.Atk+"FTK:"+Newequip.EquipData.Ftk+"HP:"+Newequip.EquipData.Hp+"\nid_"+id);
        ItemController.Instance.ItemAdd(Newequip);
        ItemController.Instance.addEquipData(Newequip.ItemID,Newequip.EquipData);
        add(Newequip);
        Player.Instance.playerData.AddItemToInventory(Newequip.ItemID);
    }
    public equip GetEquipFormID(int id)//根据id获得Item
    {
        if (EquipIDLib.ContainsKey(id)) return EquipIDLib[id];

        return null;
    }
    public void add(equip item)
    {
        EquipIDLib.Add(item.ItemID,item);
    }

    public void info()
    {
        foreach (var equip in Resources.LoadAll("Item/equip"))
        {
            add((equip)equip);
        }
    }
}
