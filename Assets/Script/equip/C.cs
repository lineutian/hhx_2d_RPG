using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : EquipObject
{
    /// <param name="TherapeuticDose">回血值</param>
    public int TherapeuticDose;
    public override void ATK()
    {
        TherapeuticDose = (int)(GlobalController.Instance.Data.T_Ftk*0.5);
        if (!IsAtk)
        {
            HurtManager.Instance.hurt(GameObject.Find("待机1").gameObject,TherapeuticDose,HurtType.Cure);
            base.ATK();
        }
    }
}
