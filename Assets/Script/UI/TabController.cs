using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : Singleton<TabController>
{
    public Transform Root;

    public int Order;

    public GameObject ButtonPrefab;
    public Transform ButtonRoot;
    private List<Tab> tabList = new List<Tab>();

    private void Start()
    {
        Root.gameObject.SetActive(false);
    }

    public void LoadAllTabs()
    {
        foreach (var item in Resources.LoadAll("Tab"))
        {
            tabList.Add((Tab)item);
        }
        tabList.Sort(
            (a, b) =>a.priority.CompareTo(b.priority) 
        );
        GenerateAllTab();
    }

    public void GenerateAllTab()
    {
        foreach (var item in tabList)
        {
            GameObject go = Instantiate(item.prefab, Root);
            item.instance= go;
            Transform quest=item.instance.transform.Find("questView/questViewport/Content");
            if (quest != null) QuestInfoController.Instance.Root = quest;
            Transform t = item.instance.transform.Find("面板");
            if (t != null) UIController.Instance.ItemPanel = t.gameObject;
            Transform sx = item.instance.transform.Find("装备/属性");
            if (sx != null) UIController.Instance.shuxinmianban = sx.gameObject;
            Transform slot = item.instance.transform.Find("Viewport/Content");
            if (slot!=null)  ItemController.Instance.SlotTransform = slot;
            go.SetActive(false);
        }

        for (int i = 0; i < tabList.Count; i++)
        {
            GameObject go = Instantiate(ButtonPrefab, ButtonRoot);
            go.GetComponent<TabButton>().Order = i;
            go.GetComponentInChildren<Text>().text = tabList[i].index;
        }
        ChangeTab(0);
    }

    public void ChangeTab(int order)
    {
        tabList[Order].instance.SetActive(false);
        Order = order;
        tabList[Order].instance.SetActive(true);
    }
    
}
