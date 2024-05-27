using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoController : Singleton<QuestInfoController>
{
    public Transform Root;
    public GameObject openQuest;

    public List<GameObject> questList;
    

    public void RefreshhUI()
    {
        if (Root==null) {Debug.Log("No Root");return;}
        foreach(var item in questList)
        {
            Destroy(item);
        }
        
        foreach (var item in QuestManager.Instance.QuestMap)
        {
            Quest q= item.Value;
            switch (q.state)
            {
                case QuestState.REQUIREMENTS_NOT_MET:
                    break;
                case QuestState.CAN_START :
                    break;
                case QuestState.IN_PROGRESS:
                    GameObject go = Instantiate(openQuest, Root);
                    go.GetComponent<OpenQuest>().QuestIndex = q.info.id;
                    go.GetComponentInChildren<Text>().text = q.info.displayName;
                    questList.Add(go);                    
                    break;
                case QuestState.CAN_FINISH:
                    GameObject ao = Instantiate(openQuest, Root);
                    ao.GetComponent<OpenQuest>().QuestIndex = q.info.id;
                    ao.GetComponentInChildren<Text>().text = q.info.displayName;
                    questList.Add(ao);
                    break;
                case QuestState.FINISHED:
                    break;
                default:
                    Debug.Log("GD001");
                    break;
            }
        }
    }
}
