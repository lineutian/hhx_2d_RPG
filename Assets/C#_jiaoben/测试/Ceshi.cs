using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ceshi : MonoBehaviour
{
    //public Dictionary<Item,string> wup=new Dictionary<Item, string>();
    public List<Item> item;
    public List<equip> equip;
    public GameObject lizhi;
    public GameObject ui_rwwc;
    public GameObject aaaa;

    public void info()
    {
        foreach (var ite in item)
        {
            GlobalController.Instance.Data.AddItemToInventory(ite.ItemID, 20);
        }
        foreach (var ite in equip)
        {
            GlobalController.Instance.Data.AddItemToInventory(ite.ItemID, 2);
            if (ite.Type==ItemType.装备)
            {
                ite.EquipData.Atk += 100;
            }
            Debug.Log(ite.EquipData.Atk);
        }
    }
    private void Awake()
    {
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GlobalController.Instance.Data.ChangeMoney(10000000);//增加金币
            GlobalController.Instance.Data.GetXP(100);//增加经验
            info();
            Instantiate(lizhi);
            ui_rwwc.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MSGcontroller.Instance.delMsg();//调用：清除左下角文本
            ui_rwwc.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(aaaa,new Vector3(0f,0f,0f), Quaternion.identity);
            GameObject a=ShadowPool.Instance.GetFormPool(1);
            ShadowPool.Instance.ReturnPool(a,1);
        }
    }
    
}
