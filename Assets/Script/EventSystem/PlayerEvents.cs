using System;
using UnityEngine;

public class PlayerEvents
{
    /// <summary>
    /// 等级改变事件
    /// </summary>
    public event Action<int> onLevelChange;
    /// <summary>
    /// 事件触发器
    /// </summary>
    /// <param name="num"></param>
    public void LevelChange(int num)
    {
        if (onLevelChange!=null)
        {
            onLevelChange(num);
        }
    }

    /// <summary>
    /// 获取经验事件
    /// </summary>
    public event Action<int> onGetExp;
    
    public void GetExp(int addExp)
    {
        if (onGetExp!=null)
        {
            onGetExp(addExp);
        }
    }

    /// <summary>
    /// 金币数量改变事件
    /// </summary>
    public event Action<int> onCoinChange;

    public void Remove_onCoinChange()
    {
        onCoinChange = null;
    }

    public void CoinChange(int _changeNum)
    {
        if (onCoinChange!=null)
        {
            onCoinChange(_changeNum);
        }
    }
    
    /// <summary>
    /// 血量改变事件
    /// </summary>
    public event Action<int> onHpChange; 
    
    public void Remove_onHpChange()
    {
        onHpChange = null;
    }

    public void HpChange(int _changeNum)
    {
        if (onHpChange!=null)
        {
            onHpChange(_changeNum);
        }
    }
    
}
