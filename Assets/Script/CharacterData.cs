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

    private int currentHealth = 100;
    private int maxHealth = 100;
    private int shieldValue=0;
    private int maxShieldValue=0;
    private int atk=2;
    private int def=0;
    private int ExtraHp=0;
    private int ExtraAtk=0;
    private int ExtraDef=0;
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
    /// </summary>
    /// <param name="_amout">改变值</param>
    public void changeShield(int _amout)
    {
        shieldValue = Mathf.Clamp(shieldValue + _amout, 0, maxShieldValue=maxHealth*5);
    }
    #endregion

    #region private
    
    #endregion
}
