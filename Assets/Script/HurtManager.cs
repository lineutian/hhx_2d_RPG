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
    public void hurt(GameObject Attacker,GameObject Defender,int _amout)
        {
            Character attacker=Attacker.GetComponent<Character>();
            Character defender=Defender.GetComponent<Character>();
            defender.changHp(_amout);
        }
    #endregion
    
}
