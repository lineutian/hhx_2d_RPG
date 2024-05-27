using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : Singleton<DebugManager>
{
    private void Start()
    {
        Debug_log<DebugManager>(null,DeBugColor.Red);
        Debug_log<DebugManager>("警告信息",DeBugColor.Yellow);
    }

    public void Debug_log<T>(object massge,DeBugColor deBugColor)
    {
        Type type = typeof(T);
        switch (deBugColor)
        {
            case DeBugColor.Red:
                Debug.Log("<color=red>"+type.Name+"</color>"+"\n"+massge);
                break;
            case DeBugColor.Yellow:
                Debug.Log("<color=yellow>"+type.Name+"</color>"+"\n"+massge);
                break;
            case DeBugColor.Green:
                Debug.Log("<color=green>"+type.Name+"</color>"+"\n"+massge);
                break;
        }
    }
}
