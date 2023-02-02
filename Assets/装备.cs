using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 装备 : MonoBehaviour
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
    public void 装备装备()
    {
        id = Int32.Parse(GameObject.Find("面板").transform.GetChild(0).name);
        GlobalController.Instance.Data.AddEquipToEquiptory(id);
    }
}
