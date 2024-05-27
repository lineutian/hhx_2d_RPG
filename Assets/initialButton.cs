using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class initialButton : MonoBehaviour
{
    private NewBehaviourScript player;
    public void Awake()
    {
        player = GameObject.Find("Player")?.GetComponent<NewBehaviourScript>();
    }

    public void Save()
    {
        player.Save();
    }

    public void Load()
    {
        player.Load();
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
