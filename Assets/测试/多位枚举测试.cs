using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 多位枚举测试 : MonoBehaviour
{
    int i;
    [System.Flags]
    public enum 多位枚举
    {
        装备1 = 1 << 0,//1 即转为二进制01 (位掩码。忘了就百度)
        装备2 = 1 << 1,//2 即10
        装备3 = 1 << 2,//4 即100
        装备4 = 1 << 3,//8 即1000
        装备5 = 1 << 4,//16 即10000
        装备6 = 1 << 5,//32 即100000
    }
    public 多位枚举 多位枚举_测试;
    
    public 多位枚举测试()
    {
   
        i = (int)多位枚举.装备1 + (int)多位枚举.装备3 + (int)多位枚举.装备6 ;
    }
    private void Start()
    {
        多位枚举_测试 = 多位枚举.装备4 | 多位枚举.装备2;
        Debug.Log(多位枚举_测试.ToString());
        Debug.Log(i);
    }
}
