using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tab", menuName = "UI/TabUI",order = 0)]
public class Tab : ScriptableObject
{
    public string index;
    public int priority;
    public GameObject prefab;
    [HideInInspector]public GameObject instance;
}
