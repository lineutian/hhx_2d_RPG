using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public static class saveSystem
{
   #region 字段
   public static SaveSetting Setting=new SaveSetting();
   
   public static int currentSaveIndex=1;
   
   public static int maxSaveIndex=6;

   public static string gameName="player";
   
   #endregion
   
   
   #region JSON
   
   public static void SaveByJson(string saveFileName, object data)//存档
   {
      var setting = new JsonSerializerSettings();
      setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      var json = JsonConvert.SerializeObject(data,setting);//JsonUtility.ToJson(data,true);
      var path = Path.Combine(Application.persistentDataPath,saveFileName);
      SqlAccess sql = new SqlAccess();
      string[] items = { "playerData"};//更改元素，与自己表对应
      string[] col = {"gameName","id" };
      string[] op = { "=","="};
      string[] val = { gameName+currentSaveIndex,currentSaveIndex.ToString()};
      DataSet ds = sql.SelectWhere("playersdata",items,col,op,val);
      if (ds != null) ;
      {
         DataTable table = ds.Tables[0];
         if (table.Rows.Count == 0)
         {
            SqlAccess.ExecuteQuery("INSERT INTO `playersdata` VALUES ('" + gameName+currentSaveIndex + "','" + currentSaveIndex+ "','" +json + "')");
         }
         else
         {
            SqlAccess.ExecuteQuery("UPDATE `playersdata` SET `playerData`='" + json + "' WHERE `gameName`='" + gameName+currentSaveIndex + "' AND `id`='" + currentSaveIndex + "'");
         }
         
      }
      File.WriteAllText(path, json);
      Debug.Log(path);
   }
   
   public static T LoadFromJson<T>(string savaFileName)//读档
   {
      SqlAccess sql = new SqlAccess();
      string[] items = { "playerData"};//更改元素，与自己表对应
      string[] col = {"gameName","id" };
      string[] op = { "=","="};
      string[] val = { gameName+currentSaveIndex,currentSaveIndex.ToString()};
      Debug.Log(gameName+currentSaveIndex);
      Debug.Log(currentSaveIndex.ToString());
      DataSet ds = sql.SelectWhere("playersdata",items,col,op,val);
      var path = Path.Combine(Application.persistentDataPath,savaFileName);
      Debug.Log(ds.Tables[0].Rows[0][0].ToString());
      var json = ds.Tables[0].Rows[0][0].ToString();
      Debug.Log(json);
      var data = JsonConvert.DeserializeObject<T>(json);//JsonUtility.FromJson<T>(json);
      return data;
   }

   public static void DeleteSaveFile()//删档
   {
      SqlAccess sql = new SqlAccess();
      string[] items = { "playerData"};//更改元素，与自己表对应
      string[] col = {"gameName","id" };
      string[] op = { "=","="};
      string[] val = { gameName+currentSaveIndex,currentSaveIndex.ToString()};
      Debug.Log(gameName+currentSaveIndex);
      Debug.Log(currentSaveIndex.ToString());
      DataSet ds = sql.SelectWhere("playersdata",items,col,op,val);
      if (ds != null) ;
      {
         DataTable table = ds.Tables[0];
         if (table.Rows.Count == 0)
         {
            Debug.Log("没有该存档");
         }
         else
         {
            SqlAccess.ExecuteQuery("DELETE FROM playersdata WHERE gameName='"+gameName+currentSaveIndex+"' and id='"+currentSaveIndex.ToString()+"'");
            Debug.Log("删除成功");
         }
         
      }
   }
   #endregion
}
