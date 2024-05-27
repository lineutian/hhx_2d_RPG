using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Data;
using static myExpected;

public class NewArchive : MonoBehaviour
{
    public string SAVE_NAME;
    public GameObject Archivepef;
    public Transform root;
    public GameObject currentSaveIndexUi;
    

    private void Awake()
    {
        Info();
    }            

    public void CreateSave()
    {
        for (int i = 1; i <= saveSystem.maxSaveIndex; i++)
        {
            bool IsSavae = false;
            SqlAccess sql = new SqlAccess();
            string[] items = { "gameName","id","playerData"};//更改元素，与自己表对应
            string[] col = { "gameName", "id"};
            string[] op = { " like ","="};
            string[] val = { saveSystem.gameName+"%",i.ToString()};
            DataSet ds = sql.SelectWhere("playersdata", items, col, op, val);
            if (ds != null) ;
            {
                DataTable table = ds.Tables[0];
                if (table.Rows.Count == 0) 
                {
                    saveSystem.currentSaveIndex = i;
                    SAVE_NAME = i.ToString();
                    saveSystem.SaveByJson(saveSystem.gameName,loadInitialSave<SaveData>());
                    GameObject archivepef=Instantiate(Archivepef, root);
                    archivepef.name=SAVE_NAME;
                    archivepef.transform.GetChild(0).gameObject.GetComponent<Text>().text = SAVE_NAME;
                    Debug.Log("创建存档成功");
                    return;
                }
            }
        }
    }

    public T loadInitialSave<T>()
    {
        string json = Resources.Load<TextAsset>("Json/initialSave").text;
        Debug.Log(json);
        var data=JsonConvert.DeserializeObject<T>(json);
        return data;
    }

    public void Info()
    {
        if (root.childCount>0)
        {
            for (int i = 0; i < root.childCount; i++)
            {
                Destroy(root.GetChild(i).gameObject);
            }
        }
        SqlAccess sql = new SqlAccess();
        string[] items = { "gameName","id","playerData"};//更改元素，与自己表对应
        string[] col = { "gameName" };
        string[] op = { " like "};
        string[] val = { saveSystem.gameName+"%"};
        DataSet ds = sql.SelectWhere("playersdata", items, col, op, val);
        if (ds != null) ;
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                SAVE_NAME = row[1].ToString();
                GameObject archivepef=Instantiate(Archivepef, root);
                archivepef.name=SAVE_NAME;
                archivepef.transform.GetChild(0).gameObject.GetComponent<Text>().text = SAVE_NAME;
            }

            if (table.Rows.Count == 0)
            {
                currentSaveIndexUi.GetComponent<Text>().text = "当前存档:无存档";
            }
            else
            {
                currentSaveIndexUi.GetComponent<Text>().text = "当前存档:" + saveSystem.currentSaveIndex;                
            }
        }
    }
}
