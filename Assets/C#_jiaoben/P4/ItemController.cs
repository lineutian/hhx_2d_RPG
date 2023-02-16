using System.Collections;
using System.Collections.Generic;
using rw;
using UnityEngine;
using UnityEngine.UI;
using static LanguageController;

public class ItemController : Singleton<ItemController>
{
    public Dictionary<ItemType, List<Item>> ItemTpyeLib = new Dictionary<ItemType, List<Item>>();
    private Dictionary<string, Item> ItemIndexLib = new Dictionary<string, Item>();
    private Dictionary<int, Item> ItemIDLib = new Dictionary<int, Item>();


    public Transform SlotTransform;
    public GameObject ItemSlot;
    private List<GameObject> SlotList = new List<GameObject>();
    public void Into()//遍历所有Resources里Item的item
    {
        foreach(var item in Resources.LoadAll("Item"))
        {
            ItemIndexLib.Add(((Item)item).Index,((Item)item));
            ItemIDLib.Add(((Item)item).ItemID,((Item)item));

            if(ItemTpyeLib.ContainsKey(((Item)item).Type))
            {
                ItemTpyeLib[((Item)item).Type].Add(((Item)item));
            }
            else
            {
                ItemTpyeLib.Add( ((Item)item).Type,new List<Item>(){((Item)item)});
            }
        }
    }

    public void ItemAdd(Item item)
    {
        ItemIDLib.Add(item.ItemID,item);

        if(ItemTpyeLib.ContainsKey(item.Type))
        {
            ItemTpyeLib[item.Type].Add(item);
        }
        else
        {
            ItemTpyeLib.Add(item.Type,new List<Item>(){item});
        }
    }
    public Item GetItemFormIndex(string index)//根据index获得Item
    {
        if (ItemIndexLib.ContainsKey(index)) return ItemIndexLib[index];

        return null;
    }
    
    public Item GetItemFormID(int id)//根据id获得Item
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
    
        
        foreach (var item in GlobalController.Instance.Data.Inventory)//在玩家Data里面遍历Inventory
        {
            Item i = GetItemFormID(item.Key);
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
    private void slotUi(Color ItemColor, Item i,string bonnt)
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
