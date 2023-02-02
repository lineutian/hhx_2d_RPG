using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : EQUIP
{
    public Animator AtkAnimator;
    public override void ATK()
    {
        if (!IsAtk)
        {
            AtkAnimator.SetTrigger("Atk");
            GameObject.Find("待机1").gameObject.transform.position += new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3));
            base.ATK();
        }
        
        
    }
}
