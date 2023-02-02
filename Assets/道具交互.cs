using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 道具交互 : MonoBehaviour
{
    public int id;
    public GameObject mianban;
    
    void Start()
    {
        mianban=GameObject.Find("beibao").transform.Find("面板").gameObject;
        id = Int32.Parse(name);
    }

    public void 呼出面板()
    {
        mianban.SetActive(true);
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
