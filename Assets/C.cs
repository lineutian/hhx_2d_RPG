using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : EQUIP
{
    public int TherapeuticDose;
    public override void ATK()
    {
        TherapeuticDose = (int)(GlobalController.Instance.Data.T_Ftk*0.5);
        if (!IsAtk)
        {
            GameObject.Find("待机1").GetComponent<NewBehaviourScript>().changHP(TherapeuticDose);
            DamageNum damageNum=ShadowPool.Instance.GetFormPool(0).GetComponent<DamageNum>();
            damageNum.GetTransform(transform.position);
            damageNum.ShowUIDamage(TherapeuticDose);
            base.ATK();
        }
    }
}
