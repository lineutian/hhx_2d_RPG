using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject shuxinmianban;
    public GameObject ItemPanel;
    public GameObject Questwindow;
    public GameObject EquipUI;
    public UITip  tip;


    public void sxgx()
    {
        if (shuxinmianban!=null) shuxinmianban.GetComponent<Text>().text = "ATK:" + Player.Instance.playerData.Atk +
                                                                           "\nFTK:" + Player.Instance.playerData.Def;
        if (EquipUI!=null) EquipUI.GetComponent<equipUI>().equipUIUPdate();
    }
}
