using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public static class saveSystem
{
   #region JSON

   public static void SaveByJson(string saveFileName, object data)//存档
   {
      var setting = new JsonSerializerSettings();
      setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      var json = JsonConvert.SerializeObject(data,setting);//JsonUtility.ToJson(data,true);
      var path = Path.Combine(Application.persistentDataPath,saveFileName);
      File.WriteAllText(path, json);
      Debug.Log(path);
   }

   public static T LoadFromJson<T>(string savaFileName)//读档
   {
      var path = Path.Combine(Application.persistentDataPath,savaFileName);
      var json = File.ReadAllText(path);
      var data = JsonConvert.DeserializeObject<T>(json);//JsonUtility.FromJson<T>(json);
      return data;
   }

   public static void DeleteSaveFile(string saveFileName)//删档
   {
      var path = Path.Combine(Application.persistentDataPath,saveFileName);
      File.Delete(path);
   }
   #endregion
}
