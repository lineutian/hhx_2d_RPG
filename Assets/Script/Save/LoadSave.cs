using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static myExpected;
using System.Data;

public class LoadSave : MonoBehaviour
{
    public void loadSave()
    {
        SqlAccess sql = new SqlAccess();
        string[] items = { "playerData"};//更改元素，与自己表对应
        string[] col = {"gameName","id" };
        string[] op = { "=","="};
        string[] val = { saveSystem.gameName+saveSystem.currentSaveIndex,saveSystem.currentSaveIndex.ToString()};
        DataSet ds = sql.SelectWhere("playersdata",items,col,op,val);
        if (ds != null) ;
        {
            DataTable table = ds.Tables[0];
            if (table.Rows.Count == 0)
            {
                Debug.Log("没有存档");
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
