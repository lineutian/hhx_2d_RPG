using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static myExpected;

public class Equip:MonoBehaviour
{
    private int[] data;

    private void Start()
    {
        load();
    }

    void load()
    {
        var json=File.ReadAllText("……/god/Assets/C#_jiaoben/1.json");
        data[1]=JsonUtility.FromJson<int>(json); 
    }
}
