using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攻击玩家 : MonoBehaviour
{
        private float sd;
        private Transform target;
        private void Awake()
        {
            sd = 3f;
            if (GameObject.FindGameObjectWithTag("Enemy")!=null)
            {
                target= GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();//获取怪物位置
            }
        }
        private void Update()
        {
            if (target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, sd * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Enemy pc = other.GetComponent<Enemy>();
            Debug.Log("222222222");
            if (pc != null)
            {
                int i;
                DamageNum damageNum=ShadowPool.Instance.GetFormPool(0).GetComponent<DamageNum>();
                damageNum.GetTransform(other.transform.position);
                damageNum.ShowUIDamage(-(i=GlobalController.Instance.Data.T_Atk));
                pc.changehp(-i);
                Destroy(this.gameObject);
            }
        }
}
