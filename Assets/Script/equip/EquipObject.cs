using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器基类
/// </summary>
public class EquipObject : MonoBehaviour
{
    public bool IsAtk=false;
    public float lifeTimer;
    public int ID;
    public GameObject equipGameObjectObject;

    public void Awake()
    {
        equipGameObjectObject = gameObject;
        EquipObjectController.LoadEquipObject(ID,gameObject.GetComponent<EquipObject>());
    }

    public int getId() {
        return ID;
    }
   
    public void setId(int _id) {
        this.ID = _id;
    }

    /// <summary>
    /// 攻击方法
    /// </summary>
    public virtual void ATK()
    {
        StartCoroutine(Atk());
    }

    IEnumerator Atk()
    {
        IsAtk = true;
        yield return new WaitForSeconds(lifeTimer);
        IsAtk = false;
    }
}
