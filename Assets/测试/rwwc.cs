using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class rwwc : MonoBehaviour
{
    private GameObject uigame;
    [SerializeField]
    private float A;

    public float Aa;
    private void Awake()
    {
        uigame=this.gameObject;
        uigame.SetActive(false);
    }

    private void Update()
    {
        A = A - Aa;
        if (A <= 0)
        {
            uigame.SetActive(false);
        }
        uigame.GetComponent<CanvasGroup>().alpha = A;
    }

    void OnEnable()
    {
        A = 1f;
        uigame.GetComponent<CanvasGroup>().alpha = A;
    }
}
