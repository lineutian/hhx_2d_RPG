using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalController : Singleton<GlobalController>
{
    public player_Data Data;
    public Text  NameText, MoneyText;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        //初始化
        if (Data == null) Data = new player_Data("玩家");
        ItemController.Instance.Into();
        equipController.Instance.info();
        LanguageController.Instance.LoadLanguagePack();
        Debug.Log(ItemController.Instance.GetItemFormIndex("血瓶").Index);
    }
    void Start()
    {
        //完成初始化后执行的内容
        StartCoroutine("Timer");
        UpdateUI();
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
    public void UpdateUI()
    {
        if (NameText == null)
            return;
        NameText.text = Data.Name;
        if (Data.Money<10000)
        {
            MoneyText.text = Data.Money.ToString();
        }
        else if (Data.Money < 1000000)
        {
            MoneyText.text = (Data.Money/10000f).ToString("F2")+"W";
        }
        else
        {
            MoneyText.text = Data.Money.ToString("E");
        }
    }
}

