using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攻击怪物 : MonoBehaviour
{
    private int sh;
    private float sd;
    private Transform target;
    public GameObject ParentGameObject;
    public float _existenceTime=10f;
    
    private void Awake()
    {
        sh = 5;
        sd = 3f;
        target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//获取玩家位置
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, sd * Time.deltaTime);
        _existenceTime -= Time.deltaTime;
        if (_existenceTime<+0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character pc = collision.GetComponent<Character>();
        if (pc != null&&pc is Player)
        {
            HurtManager.Instance.hurt(ParentGameObject,pc.gameObject,-sh,HurtType.AD);
            Destroy(this.gameObject);
        }
    }
}
