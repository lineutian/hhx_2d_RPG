using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUi : MonoBehaviour
{
    public Image Exp;

    private void Awake()
    {
        Exp.fillAmount = (float)Player.Instance.playerData.CurrentExp / (float)Player.Instance.playerData.NextLevelNeedExp;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onGetExp += ExpChangeUi;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onGetExp -=ExpChangeUi;
    }

    private void ExpChangeUi(int addExp)
    {
        Exp.fillAmount = (float)Player.Instance.playerData.CurrentExp / (float)Player.Instance.playerData.NextLevelNeedExp;
    }
}
