using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{
    public int id;
    public void Start()
    {
        SkillDataController.Instance.LoadSkillData(id,this);
    }

    public virtual void SkillEffect()
    {
        
    }
}
