using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 升级 : MonoBehaviour
{
    public int id;
    public GameObject mianban;
    
    private void Start()
    {
        mianban = GameObject.Find("面板");
    }
    private void OnEnable()
    {
        mianban = GameObject.Find("面板");
    }
    public void 武器升级()
    {
        id = Int32.Parse(GameObject.Find("面板").transform.GetChild(0).name);
        if(!equipController.Instance.EquipIDLib.ContainsKey(id))  {Debug.Log(id+"没有该物品，无法升级");return;}
        if (!Player.Instance.playerData.Inventory.ContainsKey(id))
        {
            Debug.Log(id+"没有该物品，无法升级");
            mianban.transform.GetChild(0).GetComponent<Text>().text = null;
            mianban.transform.GetChild(1).GetComponent<Text>().text = null;
        }
        else
        {
            equipController.Instance.GetEquipFormID(id).EquipData.UpGrade(1);
            //ObjectManager.PlayerData.UPdate();
            mianban.transform.GetChild(0).GetComponent<Text>().text = ItemController.Instance.GetItemFormID(id).Index;
            mianban.transform.GetChild(0).name = id.ToString();
            mianban.transform.GetChild(1).GetComponent<Text>().text = ItemController.Instance.GetItemFormID(id).DescribeIndex
                                                                        +"\nLV:"
                                                                        +equipController.Instance.GetEquipFormID(id).EquipData.LV
                                                                        +"\nATK:"
                                                                        +equipController.Instance.GetEquipFormID(id).EquipData.Atk
                                                                        +"\nFTK:"
                                                                        +equipController.Instance.GetEquipFormID(id).EquipData.Ftk
                                                                        +"\nHP:"
                                                                        +equipController.Instance.GetEquipFormID(id).EquipData.Hp;
        }
    }
}
