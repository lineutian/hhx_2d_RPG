using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject shuxinmianban;

    public void sxgx()
    {
        shuxinmianban.GetComponent<Text>().text = "ATK:" + GlobalController.Instance.Data.T_Atk +
                                                  "\nFTK:" + GlobalController.Instance.Data.T_Ftk;
    }
}
