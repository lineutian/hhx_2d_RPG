using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckedArchive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Checked()
    {
        saveSystem.currentSaveIndex = Int32.Parse(gameObject.name);
        GameObject.Find("当前存档").GetComponent<Text>().text ="当前存档:"+ saveSystem.currentSaveIndex;
    }
}
