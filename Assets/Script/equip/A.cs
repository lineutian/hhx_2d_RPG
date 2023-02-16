using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class A : EquipObject
{
    public GameObject atkPef;
    public override void ATK()
    {
        if (!IsAtk)
        {
            Instantiate(atkPef, transform.position, quaternion.identity);
            base.ATK();
        }
    }
}
