using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public Text moneyText;

    private void Awake()
    {
        moneyText.text = Player.Instance.playerData.Coins.ToString();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onCoinChange += UpdateText;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onCoinChange -= UpdateText;
    }

    private void UpdateText(int money)
    {
        if (moneyText==null)
            return;
        if (Player.Instance.playerData.Coins<1000)
        {
            moneyText.text = Player.Instance.playerData.Coins.ToString();
        }
        else if(Player.Instance.playerData.Coins<100000000)
        {
            moneyText.text = (Player.Instance.playerData.Coins / 10000f).ToString("F2") + "w";
        }
        else
        {
            moneyText.text = Player.Instance.playerData.Coins.ToString("E");
        }
    }
}
