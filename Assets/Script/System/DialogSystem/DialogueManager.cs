using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("基础<config>")]
    public GameObject dialoguePanel;

    private Queue<string> _npcDialogueQueue = new Queue<string>();
    private Queue<string> _playerDialogueQueue = new Queue<string>();

    protected override void Awake()
    {
        base.Awake();
        dialoguePanel.SetActive(false);
    }

    private void LoadDialogFromNpc(dialogInfoSO so)
    {
        if (so.npcDialogues.Length<=0)return;
        foreach (var npcSentence in so.npcDialogues)
        {
            _npcDialogueQueue.Enqueue(npcSentence);
        }

        foreach (var playerSentence in so.playerDialogues)
        {
            _playerDialogueQueue.Enqueue(playerSentence);
        }
    }

    public void ShowDialogue(dialogInfoSO so)
    {
        dialoguePanel.SetActive(true);
        LoadDialogFromNpc(so);
        dialoguePanel.transform.Find("DialogueText").GetComponent<TextMeshProUGUI>().text = so.greeting;
        Player.Instance.gameObject.GetComponent<PlayerMoveMent>().enabled = false;
    }

    public bool ContinueDialogue(dialogInfoSO so)
    {
        if (_npcDialogueQueue.Count<=0)
        {
            so?.Call();
            dialoguePanel.SetActive(false);
            Player.Instance.gameObject.GetComponent<PlayerMoveMent>().enabled = true;
            return false;
        }

        if (_playerDialogueQueue.Count<=0)
        {
            dialoguePanel.SetActive(false);
            Player.Instance.gameObject.GetComponent<PlayerMoveMent>().enabled = true;
            return false;
        }
        dialoguePanel.transform.Find("DialogueText").GetComponent<TextMeshProUGUI>().text = _npcDialogueQueue.Dequeue();
        return true;
    }
}
