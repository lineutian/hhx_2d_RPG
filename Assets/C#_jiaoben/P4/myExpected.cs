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
}