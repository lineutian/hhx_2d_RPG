using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器基类
/// </summary>
public class EQUIP : MonoBehaviour
{
    public bool IsAtk=false;
    public float lifeTimer;

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
