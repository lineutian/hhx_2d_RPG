using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterData Data=new CharacterData();

    public virtual void Awake()
    {
        
    }
}
