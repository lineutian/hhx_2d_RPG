using System.Collections;
using System.Collections.Generic;
using rw;
using UnityEngine;
using UnityEngine.UI;
using static LanguageController;
using static myExpected;

public class ItemController : Singleton<ItemController>
{
    public Dictionary<ItemType, List<ItemUI>> ItemTpyeLib = new Dictionary<ItemType, List<ItemUI>>();
    public Dictionary<string, ItemUI> ItemIndexLib = new Dictionary<string, ItemUI>();
    public Dictionary<int, ItemUI> ItemIDLib = new Dictionary<int, ItemUI>();
    public Dictionary<int,EquipData> EquipsdataLib = new Dictionary<int, EquipData>();
    public Dictionary<int,Weapon> WeaponsLib= new Dictionary<int, Weapon>();


    public Transform SlotTransform;
    public GameObject ItemSlot;
    private List<GameObject> SlotList = new List<GameObject>();
    public void Into()//遍历所有Resources里Item的item
    {
        foreach(var item in Resources.LoadAll("Item"))
        {
            ItemIndexLib.Add(((ItemUI)item).Index,((ItemUI)item));
            ItemIDLib.Add(((ItemUI)item).ItemID,((ItemUI)item));
            if(ItemTpyeLib.ContainsKey(((ItemUI)item).Type))
            {
                ItemTpyeLib[((ItemUI)item).Type].Add(((ItemUI)item));
            }
            else
            {
                ItemTpyeLib.Add( ((ItemUI)item).Type,new List<ItemUI>(){((ItemUI)item)});
            }
        }

        foreach (var weapon in Resources.LoadAll("Item/equip/weapon"))
        {
            WeaponsLib.Add(((Weapon)weapon).ItemTypeID,((Weapon)weapon));
        }
    }

    public void saveEquip(SaveData saveData)
    {
        DictionaryCopy(saveData.EquipdataLib, EquipsdataLib);
    }

    public void locaEquip(SaveData saveData)
    {
        DictionaryCopy(EquipsdataLib, saveData.EquipdataLib);
        ItemIndexLib.Clear();
        ItemTpyeLib.Clear();
        ItemIDLib.Clear();
        WeaponsLib.Clear();
        equipController.Instance.EquipIDLib.Clear();
        equipController.Instance.info();
        Into();
        foreach (var equipData in EquipsdataLib)
        {
            equip equip = equipController.Instance.GetEquipFormID(equipData.Value.ID); 
            equip Newequip = Instantiate(equip);
            Newequip.ItemID = equipData.Key;
            Newequip.Icon = equip.Icon;
            Newequip.Index = equip.Index;
            Newequip.Quality = equip.Quality;
            Newequip.Type = equip.Type;
            Newequip.DescribeIndex = equip.DescribeIndex;
            Newequip.IsStack = equip.IsStack;
            Newequip.IsUse = equip.IsUse;
            Newequip.EquipType = equip.EquipType;
            Newequip.EquipData = equipData.Value;
            
            if (!ItemIDLib.ContainsKey(equipData.Key))
            {
                ItemAdd(Newequip);
            }

            if (!equipController.Instance.EquipIDLib.ContainsKey(equipData.Key))
            {
                equipController.Instance.add(Newequip);
            }
        } ;
    }

    public void addEquipData(int id,EquipData equipData)
    {
        EquipsdataLib.Add(id,equipData);        
    }

    public void ItemAdd(ItemUI itemUI)
    {
        ItemIDLib.Add(itemUI.ItemID,itemUI);

        if(ItemTpyeLib.ContainsKey(itemUI.Type))
        {
            ItemTpyeLib[itemUI.Type].Add(itemUI);
        }
        else
        {
            ItemTpyeLib.Add(itemUI.Type,new List<ItemUI>(){itemUI});
        }
    }
    public ItemUI GetItemFormIndex(string index)//根据index获得Item
    {
        if (ItemIndexLib.ContainsKey(index)) return ItemIndexLib[index];

        return null;
    }
    
    public ItemUI GetItemFormID(int id)//根据id获得Item
    {
        if (ItemIDLib.ContainsKey(id)) return ItemIDLib[id];

        return null;
    }

    public void RefreshhUI(Dictionary<int,int> Inventory)//ui更新
    {
        if (SlotTransform == null) return;

        foreach(var item in SlotList)
        {
            Destroy(item);
        }
        SlotList.Clear();
    
        
        foreach (var item in Inventory)//在玩家Data里面遍历Inventory
        {
            ItemUI i = GetItemFormID(item.Key);
            int bont = item.Value;
            Color ItemColor=new Color();
            switch (i.Quality)
            {
                case ItemQuality.普通:
                    ItemColor = new Color(1f, 1f, 1f, 1f);
                    break;
                case ItemQuality.稀有:
                    ItemColor = new Color(0, 1f, 0, 1f);
                    break;
                case ItemQuality.贵重:
                    ItemColor = new Color(0, 0, 1f, 1f);
                    break;
                case ItemQuality.史诗:
                    ItemColor = new Color(0.5f, 0, 1f, 1f);
                    break;
                case ItemQuality.传世:
                    ItemColor = new Color(1f, 0.5f, 0, 1f);
                    break;
                case ItemQuality.永恒:
                    ItemColor = new Color(1f, 0, 0, 1f);
                    break;
            }
            if (i.IsStack==true) 
            {
                slotUi(ItemColor, i, bont<2?" ":bont.ToString());
            }
            else
            {
                for(int zx=bont;zx>=1;zx--)
                {
                        slotUi(ItemColor,i," ");
                }
            }
            
        }
    }
    private void slotUi(Color ItemColor, ItemUI i,string bonnt)
    {
        GameObject slot = Instantiate(ItemSlot, SlotTransform);
        slot.name = i.ItemID.ToString();
        slot.transform.Find("mingzi").GetComponent<Text>().text = GetLocalT(i.Index);
        slot.transform.Find("shulaing").GetComponent<Text>().text =bonnt;
        slot.transform.Find("Icon").GetComponent<Image>().sprite = i.Icon;
        slot.transform.Find("bj").GetComponent<Image>().color = ItemColor;
        SlotList.Add(slot);
    }//Ui更新的整合
}
