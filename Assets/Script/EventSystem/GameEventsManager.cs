using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public PlayerEvents playerEvents;

    public QuestEvents questEvents;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.Log("该场景已经存在GameEventsManager");
        }
        instance = this;
        Debug.Log("创建成功");
        questEvents = new QuestEvents();
        playerEvents = new PlayerEvents();
    }
}
