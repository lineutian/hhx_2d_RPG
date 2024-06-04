using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    [HideInInspector]public dialogInfoSO currentDialogInfoSo;

    protected  void Awake()
    {
        UIController.Instance.tip.Add("对话",transform,StartDialog);
    }

    private void StartDialog()
    {
        if (currentDialogInfoSo != null)
        {
            DialogueManager.Instance.ShowDialogue(currentDialogInfoSo);
            UIController.Instance.tip.Remove(transform);
            UIController.Instance.tip.Add("牛逼",transform,ContinueDialog);
        }
    }

    private void ContinueDialog()
    {
        if (currentDialogInfoSo != null)
        {
            if (!DialogueManager.Instance.ContinueDialogue(currentDialogInfoSo))
            {
                UIController.Instance.tip.Remove(transform);
                UIController.Instance.tip.Add("对话",transform,StartDialog);  
            }
        }
    }
}
