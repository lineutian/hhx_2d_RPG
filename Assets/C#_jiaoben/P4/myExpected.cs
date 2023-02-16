using System;
using System.Collections.Generic;
using UnityEngine;
public static class myExpected
{
    public static T listRondom<T>(this List<T> list)//在链表内随机数
    {
        var index = UnityEngine.Random.Range(0,list.Count);
        var result = list[index];
        return result;
    }
    
    public static Dictionary<T, K> DictionaryCopy<T, K>(Dictionary<T, K> A, Dictionary<T, K> B)
    {
        A.Clear();
        foreach (var b in B)
            A.Add(b.Key, b.Value);
        return A;
    }
}