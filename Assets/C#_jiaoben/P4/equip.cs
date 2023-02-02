using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using static myExpected;


[CreateAssetMenu(fileName ="Item",menuName ="自定义/装备",order=0)]
public class equip : Item
{
    public EquipData EquipData=new EquipData();
    public EquipType EquipType;
    public GameObject EquipPef;
}





