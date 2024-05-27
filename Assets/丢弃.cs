using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 丢弃 : MonoBehaviour
{
    public int id;
    public GameObject mianban;
    
    private void Start()
    {
        mianban = GameObject.Find("面板");
        mianban.transform.GetChild(0).GetComponent<Text>().text = null;
        mianban.transform.GetChild(1).GetComponent<Text>().text = null;
        mianban.SetActive(false);
    }

    private void OnEnable()
    {
        mianban = GameObject.Find("面板");
    }

    public void 丢弃道具()
    {
        id = Int32.Parse(GameObject.Find("面板").transform.GetChild(0).name);
        Player.Instance.playerData.AddItemToInventory(id,-99);
        if (!Player.Instance.playerData.Inventory.ContainsKey(id))
        {
            mianban.transform.GetChild(0).GetComponent<Text>().text = null;
            mianban.transform.GetChild(1).GetComponent<Text>().text = null;
            mianban.SetActive(false);
        }
        mianban.SetActive(false);
    }
}
