using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ShadowPool : Singleton<ShadowPool>
{
    public List<GameObject> shadowPrefabs;
    private List<Queue<GameObject>> availableObjects=new List<Queue<GameObject>>();
    public int shadowCount;

    protected override void Awake()
    {
        base.Awake();
        foreach (var gameObjectPef in shadowPrefabs)
        {
            new GameObject(gameObjectPef.ToString()).transform.parent=gameObject.transform;
        }
    }

    public void Start()
    {
        initialization();
        for (int i = 0; i < availableObjects.Count; i++)
        {
            FillPool(i);
        }
    }

    public void initialization()
    {
        for (int i = 0; i < shadowPrefabs.Count; i++)
        {
            availableObjects.Add(new Queue<GameObject>());
        }
    }

    public void FillPool(int amount)
    {
        for (int i = 0; i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefabs[amount]);
            newShadow.transform.SetParent(transform.GetChild(amount).transform);
            //取消启用，返回对象池
            ReturnPool(newShadow,amount);
        }
    }

    public void ReturnPool(GameObject gameObject,int amount)
    {
        gameObject.SetActive(false);
        
        availableObjects[amount].Enqueue(gameObject);
    }

    public GameObject GetFormPool(int amount)
    {
        if (availableObjects[amount].Count == 0)
        {
            FillPool(amount);
        }
        var outShadow = availableObjects[amount].Dequeue();
        outShadow.SetActive(true);
        return outShadow;
    }
}
