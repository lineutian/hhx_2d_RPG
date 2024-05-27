using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public String PLAYER_NAME_KEY;
    public static Player Instance;
    public PlayerData playerData=new PlayerData();
    
    public override void Awake()
    {
        characterType = CharacterType.Player;
        if(Instance == null)
        {
            Instance = (Player)this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
        EventCenter.Instance.AddEventListener<Player>("Player_die",Die);
        Data = playerData;
    }

    private void Start()
    {
        xuetiao.Instance.updatehp(Data.CurrentHealth,Data.MaxHealth);
    }

    private void OnEnable()
    {
        playerData.PlayerAddEvent();
    }

    private void OnDisable()
    {
        playerData.PlayerMoveEvent();
    }

    private void Die(Player player)
    {
        MSGcontroller.Instance.addMsg("<color=red>you die !!!!</color>");
        player.playerData.changHp(player.playerData.MaxHealth-player.playerData.CurrentHealth);
        player.gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        player.playerData.LevelUp(-1);
    }
    
}
