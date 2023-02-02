using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum battlestate
{
    Start,playerTurn,EnemyTurn,won,lost
}
public class bamesystem : MonoBehaviour
{
    public battlestate state;
    public GameObject playerperfeb;
    public GameObject enemyperfeb;

    private player_baokemeng player_1;
    private player_baokemeng enemy_1;
    // Start is called before the first frame update
    void Start()
    {
        state = battlestate.Start;
        Setupbattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Setupbattle()
    {
        GameObject player= Instantiate(playerperfeb);
        player_1 = player.GetComponent<player_baokemeng>();
        GameObject enemy = Instantiate(enemyperfeb);//生成预制体，并创建一个实例enemy储存
        enemy_1 = enemy.GetComponent<player_baokemeng>();//获取脚本player_baokemeng
    }
}
