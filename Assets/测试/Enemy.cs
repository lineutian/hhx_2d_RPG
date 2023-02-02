using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region 字段
        [SerializeField]
        protected private string Enemy_Name;
        [SerializeField]
        protected private int Enemy_LV;
        [SerializeField]
        protected private int Enemy_MaxHp;
        [SerializeField]
        protected private int Enemy_ATK;
        [SerializeField]
        protected private GameObject ATK;
        [SerializeField]
        protected private float ATK_jg;

        protected private bool Isatk=true;
    
        [SerializeField]
        protected private int Enemy_CurrentHp;
        [SerializeField]
        protected float Enemy_MoveSpeed;
        [SerializeField]
        protected private float AttackRange;//攻击距离
        protected private float speed;
    
        protected Transform target;
        [SerializeField]
        protected private float distance;//追击距离
        [SerializeField]
        protected private Text text;
        
        public Image xue;
        public Image xue_1;
        [SerializeField] private float xue_time_1;//serializefield 可以在外部通过面板改变private变量
        private float xue_chazhi;
        #endregion
    
    // Update is called once per frame
    private void Start()
    {
        speed = Enemy_MoveSpeed;
        Enemy_CurrentHp = Enemy_MaxHp;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//获取玩家位置
    }
    private void Update()
    {
        updatehp();
        xuetiaohuanchong();
        text.text = Enemy_CurrentHp.ToString();
        Move();
    }
    protected virtual void Move()//移动方式
    {
        if (Vector2.Distance(transform.position,target.position)<distance&& Vector2.Distance(transform.position, target.position)>AttackRange)//Distance 返回两点的距离
        {
            Enemy_MoveSpeed = speed;
            transform.position = Vector2.MoveTowards(transform.position, target.position, Enemy_MoveSpeed * Time.deltaTime);//moveTowards(1,2,3)   1点 移向 2点 距离不超过 3
        }
        else if (Vector2.Distance(transform.position, target.position) <=AttackRange)
        {
            StartCoroutine(Attack());
            Enemy_MoveSpeed = 0;
        }
    }
    protected virtual IEnumerator Attack()
    {
        if (Isatk)
        {
            Isatk = false;
            Instantiate(ATK, transform);
            yield return new WaitForSeconds(ATK_jg);
            Isatk = true;
        }
    }

    #region 血条ui
    private void xuetiaohuanchong()
        {
            if (xue_1.fillAmount > xue.fillAmount)//血条缓冲效果
            {
                xue_1.fillAmount -= (float)xue_chazhi/ xue_time_1;
            }
            else
            {
                xue_1.fillAmount = xue.fillAmount;
            }
        }
        private void updatehp()
        {
            xue.fillAmount = (float)Enemy_CurrentHp / (float)Enemy_MaxHp;
            xue_chazhi = (xue_1.fillAmount - xue.fillAmount);
        }

        public void changehp(int amout)
        {
            Enemy_CurrentHp = Mathf.Clamp(Enemy_CurrentHp + amout, 0, Enemy_MaxHp);
            kill();
        }
    #endregion

    #region 死亡

    void kill()
    {
        if (Enemy_CurrentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    #endregion
}
