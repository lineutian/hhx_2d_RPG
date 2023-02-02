using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSGcontroller : Singleton<MSGcontroller>
{
    private string CurrrentText;//??????
    public Text MsgText;
    public string addMsg(string content)
    {
        string Prefix ="<color=\"red\">"+"[" + System.DateTime.Now.ToString("HH:mm:ss")+"]"+"</color>";//??,color???????????     \"     ???????
        CurrrentText = CurrrentText +"\n"+ Prefix + content;
        MsgText.text = CurrrentText;
        if (CurrrentText.Length>6499)
        {
            delMsg();
        }
        return CurrrentText;
    }
    public string delMsg()
    {//??????
        CurrrentText = null;
        MsgText.text = CurrrentText;
        return CurrrentText;
    }
}
