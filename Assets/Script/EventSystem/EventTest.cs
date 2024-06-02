using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //为“EventTest_Print”名字的事件注册一个print方法
        EventCenter.Instance.AddEventListener<string>("EventTest_Print",print);
    }
    
    public void print(string text)
    {
        Debug.Log("Event事件测试输出:"+text);
        GameEventsManager.instance.playerEvents.GetExp(150);
    }

    public void textadd()
    {
        //Info为string类型
        EventCenter.Instance.EventTrigger<string>("EventTest_Print",MSGcontroller.Instance.MsgText.text);
        Player.Instance.playerData.GetCoins(100);
        EventCenter.Instance.EventTrigger("收集金币");
        UIController.Instance?.tip.Add("收集金币",GameObject.Find("Andromeda").transform,null);
    }
    
}
