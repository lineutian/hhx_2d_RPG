using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuest : MonoBehaviour
{
    public string QuestIndex;

    public QuestAboutUI questAboutUI;

    private void Awake()
    {
        questAboutUI = GameObject.Find("quest").GetComponent<QuestAboutUI>();
    }

    public void Click()
    {
        questAboutUI.SetState(QuestManager.Instance.GetQuestById(QuestIndex));
    }
}
