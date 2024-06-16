using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class SuitTest : EquipSuitBase
{
    private const int _addHp=5;
    private Timer _IsAddHp;

    private void Awake()
    {
        _IsAddHp=TimerManager.Instance.AddTimer(EquipSuit, 5f, true);
    }
    

    public  override  void EquipSuit()
    {
        // 装备套装的逻辑
        HurtManager.Instance.hurt(Player.Instance.gameObject,_addHp,HurtType.Cure);
    }

    private void OnDestroy()
    {
        _IsAddHp.Stop();
    }
}
