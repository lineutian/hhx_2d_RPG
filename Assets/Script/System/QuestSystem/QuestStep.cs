using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    //是否完成
    private bool isFinished = false;

    private string questId;

    //任务步骤描述
    public string descriptio;

    public void InitializeQuestStep(string questId)
    {
        this.questId = questId;
    }
    //完成任务步骤
    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            GameEventsManager.instance.questEvents.AdvanceQuest(questId);
            Destroy(this.gameObject);
        }
    }
}
