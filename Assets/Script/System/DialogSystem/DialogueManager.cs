using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("基础<config>")]
    [SerializeField] private GameObject dialoguePanel;

    private Queue<string> _npcDialogueQueue = new Queue<string>();
    private Queue<string> _playerDialogueQueue = new Queue<string>();

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
        LoadDialogFromNpc(so);
        dialoguePanel.GetComponent<TextMeshProUGUI>().text = so.greeting;
    }

    public bool ContinueDialogue(dialogInfoSO so)
    {
        if (_npcDialogueQueue.Count<=0)
        {
            so?.Call();
            return false;
        }

        if (_playerDialogueQueue.Count<=0)
        {
            return false;
        }
        dialoguePanel.GetComponent<TextMeshProUGUI>().text = _npcDialogueQueue.Dequeue();
        return true;
    }
}
