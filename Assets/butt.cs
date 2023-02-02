using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class butt : MonoBehaviour
{
    public Button bth;
    public GameObject cc;

    private void Awake()
    {
        cc.SetActive(false);
    }

    private void Start()
    {
        bth.onClick.AddListener(bto);
    }
    

    void bto()
    {
        cc.SetActive(true);
        cc.transform.GetChild(0).GetComponent<Text>().text= transform.GetChild(2).GetComponent<Text>().text;
    }
}
