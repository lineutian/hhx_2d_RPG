using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : Singleton<GlobalController>
{
    public player_Data Data;
    public Text NameText;
    protected override void Awake()
    {
        base.Awake();
        ///防止因为切换场景而被销毁
        DontDestroyOnLoad(this.gameObject);
        //初始化
        if (Data == null) Data = new player_Data("玩家");
        ItemController.Instance.Into();
        equipController.Instance.info();
        LanguageController.Instance.LoadLanguagePack();
        TabController.Instance.LoadAllTabs();
        Debug.Log(ItemController.Instance.GetItemFormIndex("血瓶").Index);
    }
    void Start()
    {
        //完成初始化后执行的内容
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        //每帧都调用
    }
    void OnApplicationQuit()
    {
        //当退出程序时调用的内容
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            //每秒调用一次
        }
    }
    
}

