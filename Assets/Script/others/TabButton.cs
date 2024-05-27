using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton : MonoBehaviour
{
    public int Order;

    public void Click()
    {
        TabController.Instance.ChangeTab(Order);
        
    }
}
