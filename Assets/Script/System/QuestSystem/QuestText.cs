using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    public bool IsQuestText;
    [Header("文本")]

    [SerializeField] private GameObject displayNameText;
    
    [SerializeField] private GameObject descriptionText;
    
    [SerializeField] private GameObject levelReuirementsText;
    

    public void SetState(QuestState newState,bool startPoint, bool finishPoint,Quest quest)
    {
        GameObject questStepPrefab=null;
        QuestStep questStep = null;
        if (quest.CurrentStepExists())
        {
            questStepPrefab = quest.info.questStepPrefabs[quest.currentQuestStepIndex];
            questStep=questStepPrefab.GetComponent<QuestStep>();
        }
        Text displayName = displayNameText.GetComponent<Text>();
        Text description = descriptionText.GetComponent<Text>();
        Text levelRequirements = levelReuirementsText.GetComponent<Text>();
        IsQuestText = false;
        switch (newState)
        {
            case QuestState.REQUIREMENTS_NOT_MET:
                if (startPoint)
                {
                    displayName.text = quest.info.displayName;
                    description.text = quest.info.descriptio;
                    levelRequirements.text=
                        "<color=red>不符合等级要求：" + quest.info.levelReuirements+"</color>";
                    IsQuestText = true;
                }
                break;

            case QuestState.CAN_START:
                if (startPoint)
                {
                    displayName.text = quest.info.displayName;
                    description.text = quest.info.descriptio;
                    levelRequirements.text=
                        "<color=green>符合等级要求：" + quest.info.levelReuirements+"</color>";
                    IsQuestText = true;
                }
                break;
            
            case QuestState.IN_PROGRESS:
                if (finishPoint)
                {
                    displayName.text = quest.info.displayName;
                    description.text = questStep.descriptio;
                    levelRequirements.text = " ";
                    IsQuestText = true;
                }
                break;
            
            case QuestState.CAN_FINISH:
                if (finishPoint)
                {
                    displayName.text = quest.info.displayName;
                    description.text = "已满足任务条件可以交付";
                    levelRequirements.text = " ";
                    IsQuestText = true;
                }
                break;
            
            case QuestState.FINISHED:
                gameObject.SetActive(false);
                break;
            
            default:
                Debug.LogWarning(newState);
                break;
        }
    }
}
