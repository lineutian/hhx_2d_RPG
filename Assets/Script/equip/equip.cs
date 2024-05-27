using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using static myExpected;


[CreateAssetMenu(fileName ="Item",menuName ="自定义/装备",order=0)]
public class equip : ItemUI
{
    public EquipData EquipData=new EquipData();
    public EquipType EquipType;
    public GameObject EquipGameObject => equipObject();
    
    public GameObject equipObject()
    {
        if (!EquipObjectController._equipObjects.ContainsKey(ItemTypeID))
        {
            return null;
        }
        return EquipObjectController.getEquipObject(ItemTypeID).equipGameObjectObject;
    }
}





