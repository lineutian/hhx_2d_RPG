using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 伤害计算管理器
/// </summary>
public class HurtManager : Singleton<HurtManager>
{
    #region API
    /// <summary>
    /// 伤害
    /// </summary>
    /// <param name="Attacker">攻击者</param>
    /// <param name="Defender">受击者</param>
    /// <param name="_amout">伤害</param>
    /// <param name="hurtType">伤害类型</param>
    public void hurt(GameObject Attacker,GameObject Defender,int _amout,HurtType hurtType)
    {
            int hurtValue=0;
            Character attacker=Attacker.GetComponent<Character>();
            Character defender=Defender.GetComponent<Character>();
            CharacterData attackerData = attacker.Data;
            CharacterData defenderData = defender.Data;
            switch (hurtType)
            {
                case HurtType.AD:
                    hurtValue = _amout - (attackerData.Atk - defenderData.Def);
                    defenderData.changHp(hurtValue);
                    break;
                case HurtType.Cure:
                    hurtValue = _amout;
                    defenderData.changHp(hurtValue);
                    break;
                default:
                    hurtValue = _amout;
                    defenderData.changHp(hurtValue);
                    break;
            }
            DamageNum damageNum=ShadowPool.Instance.GetFormPool(0).GetComponent<DamageNum>();
            damageNum.GetTransform(defender.transform.position);
            damageNum.ShowUIDamage(hurtValue,hurtType);
    }

    public void hurt(GameObject Defender,int _amout,HurtType hurtType)
    {
        Character defender=Defender.GetComponent<Character>();
        CharacterData defenderData = defender.Data;
        DamageNum damageNum=ShadowPool.Instance.GetFormPool(0).GetComponent<DamageNum>();
        damageNum.GetTransform(defender.transform.position);
        damageNum.ShowUIDamage(_amout);
        defenderData.changHp(_amout);
    }
    #endregion
    
}
