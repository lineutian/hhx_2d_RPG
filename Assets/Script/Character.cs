using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth;
    public int CurrentHealth { get { return currentHealth; } }
    public int MaxHealth { get { return maxHealth; } }

    #region api
    /// <summary>
    /// 血量改变
    /// </summary>
    /// <param name="_amout">伤害值</param>
    public void changHp(int _amout)
    {
        currentHealth = Mathf.Clamp(currentHealth + _amout, 0, maxHealth);
    }
    #endregion
}
