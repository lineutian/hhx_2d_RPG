using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class LanguageController : Singleton<LanguageController>
{
    //调度不同语言包，加载语言包
    private Dictionary<string, Language> LanguageLib = new Dictionary<string, Language>();
    private static Language CurrentLanguage;//当前语言包

    public string Defaultlanguage;//默认语言包

    public void LoadLanguagePack()
    {
        foreach(var item in Resources.LoadAll("Langauage"))
        {
            string json = ((TextAsset)item).text;//转换成文本
            Language lan = JsonConvert.DeserializeObject<Language>(json);
            AddLanguagePackToLib(lan);
        }
        CurrentLanguage = LanguageLib[Defaultlanguage];//当前语言变为默认语言
    }
    void AddLanguagePackToLib(Language lan)
    {
        if (!LanguageLib.ContainsKey(lan.LanguageType))
        {
            LanguageLib.Add(lan.LanguageType, lan);
        }
        else
        {
            foreach(var item in lan.Lib)
            {
                if (LanguageLib[lan.LanguageType].Lib.ContainsKey(item.Key))
                    LanguageLib[lan.LanguageType].Lib[item.Key] = item.Value;
                else 
                    LanguageLib[lan.LanguageType].Lib.Add(item.Key, item.Value);
            }
        }
    }

    public static string GetLocalT(string index)
    {
        if (CurrentLanguage.Lib.ContainsKey(index))
            return CurrentLanguage.Lib[index];
        else
            return index;
    }
}
public class Language
{
    public string LanguageType;//语种
    public Dictionary<string, string> Lib;//词库

    public Language() { }
    public Language(string type , Dictionary<string,string> lib)
    {
        LanguageType = type;
        Lib = lib;
    }
}