using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinsQuestStep : QuestStep
{
    [SerializeField]
    private int coinsCollected = 0;
    [SerializeField]
    private int coinsToComplate = 100;

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onCoinChange += CoinsCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onCoinChange -= CoinsCollected;
    }

    private void CoinsCollected(int _num)
    {
        if (coinsCollected<coinsToComplate)
        {
            coinsCollected+=_num;
            Debug.Log(coinsCollected);
        }

        if (coinsCollected>=coinsToComplate)
        {
            FinishQuestStep();
            Debug.Log("任务完成");
        }
    }
}
