using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    /// <summary>
    /// 伤害类型
    /// </summary>
    /// <param name="AD">物理</param>
    /// <param name="AP">法术</param>
    /// <param name="TrueDamage">真实</param>
    /// <param name="Crue">治疗</param>
    /// <param name="Shield">护盾</param>
public enum HurtType
{
    /// <param name="AD">物理</param>
    AD,
    /// <param name="AP">法术</param>
    AP,
    /// <param name="TrueDamage">真实</param>
    TrueDamage,
    /// <param name="Crue">治疗</param>
    Cure,
    /// <param name="Shield">护盾</param>
    Shield
}
