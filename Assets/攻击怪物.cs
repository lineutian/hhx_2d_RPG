using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攻击怪物 : MonoBehaviour
{
    private int sh;
    private float sd;
    private Transform target;
    private void Awake()
    {
        sh = 5;
        sd = 3f;
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//获取玩家位置
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, sd * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewBehaviourScript pc = collision.GetComponent<NewBehaviourScript>();
        if (pc != null)
        {
            pc.changHP(-sh);
            Destroy(this.gameObject);
        }
    }
}
