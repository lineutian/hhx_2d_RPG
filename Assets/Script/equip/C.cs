using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : WeaponAtk
{
    /// <param name="TherapeuticDose">回血值</param>
    public int TherapeuticDose;

    public int CureValue;
    public override void ATK()
    {
        TherapeuticDose = (int)(Player.Instance.playerData.Def*0.5)+CureValue;
        if (!IsAtk)
        {
            HurtManager.Instance.hurt(ObjectManager.Player,TherapeuticDose,HurtType.Cure);
            base.ATK();
        }
    }
}
