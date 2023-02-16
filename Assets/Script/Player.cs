using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public String PLAYER_NAME_KEY;
    public static Player Instance;
    public override void Awake()
    {
        characterType = CharacterType.Player;
        Data=new PlayerData(PLAYER_NAME_KEY);
        if(Instance == null)
        {
            Instance = (Player)this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        xuetiao.Instance.updatehp(Data.CurrentHealth,Data.MaxHealth);
    }
    
}
