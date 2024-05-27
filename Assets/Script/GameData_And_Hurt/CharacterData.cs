using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData
{
    public CharacterData(){}
    public CharacterData(CharacterType characterType)
    {
       this.characterType=characterType;
    }

    private protected int currentHealth = 100;
    private protected int maxHealth = 100;
    private protected int shieldValue=100;
    private protected int maxShieldValue=1000;
    private protected int atk=200;
    private protected int def=10;
    private protected  int ExtraHp=0;
    private protected  int ExtraAtk=0;
    private protected  int ExtraDef=0;
    public CharacterType characterType;
    public int Atk { get { return atk + ExtraAtk; } }
    public int Def { get { return def + ExtraDef; } }
    public int CurrentHealth { get { return currentHealth; } }
    public int MaxHealth { get { return maxHealth+ExtraHp; } }
    public int ShieldValue { get { return shieldValue; } }

    #region api
    /// <summary>
    /// 当前血量改变
    /// </summary>
    /// <param name="_amout">伤害值</param>
    public virtual void changHp(int _amout)
    {
        currentHealth = Mathf.Clamp(currentHealth + _amout, 0, MaxHealth);
        if (currentHealth<=0)
        {
            die();
        }
    }
    /// <summary>
    /// 最大血量改变
    /// </summary>
    /// <param name="_amout">改变值</param>
    public void setAddMaxHp(int _amout)
    {
        maxHealth = maxHealth + _amout;
    }
    /// <summary>
    /// 护盾值改变
    /// 最大护盾值为最大五倍生命
    /// </summary>
    /// <param name="_amout">改变值</param>
    public void changeShield(int _amout)
    {
        shieldValue = Mathf.Clamp(shieldValue + _amout, 0, maxShieldValue=maxHealth*5);
    }
    #endregion

    #region private

    public virtual void die()
    {
        
    }
    #endregion
}
