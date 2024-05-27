using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestAboutUI : MonoBehaviour
{
    [Header("文本")]

    [SerializeField] private GameObject displayNameText;
    
    [SerializeField] private GameObject descriptionText;
    
    [SerializeField] private GameObject levelReuirementsText;

    public void SetState(Quest quest)
    {
        QuestState newState = quest.state;
        GameObject questStepPrefab;
        QuestStep questStep = null;
        if (quest.CurrentStepExists())
        {
            questStepPrefab = quest.info.questStepPrefabs[quest.currentQuestStepIndex];
            questStep=questStepPrefab.GetComponent<QuestStep>();
        }
        Text displayName = displayNameText.GetComponent<Text>();
        Text description = descriptionText.GetComponent<Text>();
        Text levelRequirements = levelReuirementsText.GetComponent<Text>();
        switch (newState)
        {
            case QuestState.REQUIREMENTS_NOT_MET:
                break;
            case QuestState.CAN_START:
                break;
            case QuestState.IN_PROGRESS:
                    displayName.text = quest.info.displayName;
                    description.text = questStep.descriptio;
                    levelRequirements.text = "<color=yellow>正在进行中</color>";
                break;
            
            case QuestState.CAN_FINISH:
                    displayName.text = quest.info.displayName;
                    description.text = "已满足任务条件可以交付";
                    levelRequirements.text = "<color=green>任务已完成</color>";
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
