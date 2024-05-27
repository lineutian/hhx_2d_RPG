using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攻击玩家 : MonoBehaviour
{
        private float sd;
        private Transform target;
        public HurtType HurtType;
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
                GameObject Player = GameObject.FindWithTag("Player");
                /*DamageNum damageNum=ShadowPool.Instance.GetFormPool(0).GetComponent<DamageNum>();
                damageNum.GetTransform(other.transform.position);
                damageNum.ShowUIDamage(-(i=GlobalController.Instance.Data.T_Atk),HurtType);
                pc.changehp(-i);*/
                HurtManager.Instance.hurt(Player,pc.gameObject,-(int)(ObjectManager.PlayerData.Atk*0.5f),HurtType);
                Destroy(this.gameObject);
            }
        }
}
