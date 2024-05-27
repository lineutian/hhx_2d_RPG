using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象控制器
/// </summary>
/// <param name=""><b>所有参数</b></param>
/// <param name="Player">玩家对象</param>
public class ObjectManager : Singleton<ObjectManager>
{
    public static GameObject Player;
    public static PlayerData PlayerData;

    protected override void Awake()
    {
        base.Awake();
        Player = GetGameObject("Player");
        PlayerData = Player.GetComponent<Player>().playerData;
        
    }

    public GameObject GetGameObject(string Name)
    {
        var gameObject = GameObject.Find(Name).gameObject;
        return gameObject;
    }
}
