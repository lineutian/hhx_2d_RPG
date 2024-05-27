using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private int playerLevel;

    public void Awake()
    {
        playerLevel = Player.Instance.playerData.Level;
        GetComponent<Text>().text = $"LV:<size=36>{playerLevel}</size>";
    }

    public void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onLevelChange += LevelTextUpdate;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onLevelChange -= LevelTextUpdate;
    }

    public void LevelTextUpdate(int a)
    {
        playerLevel=a;
        GetComponent<Text>().text = $"LV:<size=36>{playerLevel}</size>";
    }
}
