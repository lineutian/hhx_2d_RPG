using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipObjectController : Singleton<EquipObjectController>
{
    private static Dictionary<int, EquipObject> _equipObjects = new Dictionary<int, EquipObject>();

    public static EquipObject getEquipObject(int id)
    {
        EquipObject _equipObject = _equipObjects[id];
        return (EquipObject)_equipObject;
    }

    public static void LoadEquipObject(int _id,EquipObject _equipObject)
    {
        if (!_equipObjects.ContainsKey(_id))
        {
            _equipObjects.Add(_id,_equipObject);
        }
        else
        {
            return;
        }
    }
}
