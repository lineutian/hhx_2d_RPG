using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 蝙蝠 : Enemy
{
    protected override void Move()
    {
        if (Data.CurrentHealth < 100 && Vector2.Distance(transform.position, target.position) < distance)
        {
            Enemy_MoveSpeed = speed;
            transform.position = Vector2.MoveTowards(transform.position, target.position, -Enemy_MoveSpeed * Time.deltaTime);
        }
        else
        {
            base.Move();
        }
    }
}
