using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.UI;

public class UITip : MonoBehaviour
{
    #region mono
    private  void Awake()
    {
        UIController.Instance.tip = this;
    }

    private void Update()
    {
        RefreshEnabledTip();
        ChooseTipInput();
        CallTip();
    }

    #endregion
    

    #region var

    /// <summary>
    /// 所有tip的父物体
    /// </summary>
    [SerializeField] private Transform tipParent;

    /// <summary>
    /// 被选择的tip
    /// </summary>
    [ShowInInspector]
    private int _chosen;

    /// <summary>
    /// 存储了所有tip的数据
    /// </summary>
    private List<UITipData> _tips = new List<UITipData>();

    #endregion

    #region api
    /// <summary>
    /// 新建交互提示
    /// </summary>
    /// <param name="text">交互提示显示的文字</param>
    /// <param name="trans">物体的transform（用于根据距离隐藏交互提示）</param>
    /// <param name="call">触发后调用的函数</param>
    /// <param name="distance">显示交互提示的距离</param>
    public void Add(string text, Transform trans, Action call, float distance = 2f)
    {
        Debug.Log($"添加交互提示{text}，来自{trans.gameObject.name}");
        UITipData temp = new UITipData(text, call, trans,
            GameObject.Instantiate(Resources.Load<GameObject>("Pef/UiPef/Tip/Tip"), tipParent).GetComponent<UIOnTip>(),distance);
        temp.controller.Setup(temp);
        _tips.Add(temp);
        CheckChosenTip();
    }
    /// <summary>
    /// 移除交互提示
    /// </summary>
    /// <param name="trans">要移除的交互提示添加时使用的Transform</param>
    public void Remove(Transform trans)
    {
        UITipData temp = _tips.Find((tmp) => tmp.trans.Equals(trans));
        Destroy(temp.controller.gameObject);
        _tips.Remove(temp);
        CheckChosenTip();
        Debug.Log($"移除交互提示{temp.text}");
    }

    /// <summary>
    /// 移除所有交互提示
    /// </summary>
    public void RemoveAll()
    {
        foreach (UITipData uiTipData in _tips)
        {
            Destroy(uiTipData.controller.gameObject);
        }

        _tips.RemoveAll((x) => true);
        CheckChosenTip();
        Debug.Log("已经移除所有交互提示");
    }
    #endregion

    #region private
    /// <summary>
    /// 刷新要Enable的Tip
    /// </summary>
    private void RefreshEnabledTip()
    {
        foreach (UITipData tipData in _tips)
        {
            try
            {
                float disTemp = Vector3.Distance(tipData.trans.position, Player.Instance.transform.position);
                if (disTemp < tipData.distance && !tipData.enabled)
                {
                    tipData.controller.Enable();
                    CheckChosenTip();
                }
                else if (disTemp >= tipData.distance && tipData.enabled)
                {
                    tipData.controller.Disable();
                    CheckChosenTip();
                }
            }
            // 如果transform组件不存在就删除交互提示
            catch (MissingReferenceException e)
            {
                Debug.Log($"{tipData.text}对应的GameObject不存在！/n 详细信息:{e.Message}");
                Remove(tipData);
            }
        }
    }
    /// <summary>
    /// 刷新被选中的Tip，需要在被选中的Tip被修改后或对Tip进行了添加删除操作后调用
    /// </summary>
    private void CheckChosenTip()
    {
        if (HaveEnabled())
        {
            try
            {
                // 如果被选中的tip不可用
                if (!_tips[_chosen].enabled)
                {
                    _chosen = FindNextEnabled();
                }
            }
            // 如果被选中的tip不存在
            catch (Exception e)
            {
                Console.WriteLine(e);
                _chosen = FindLastEnabled();
            }

            // 将选中的交互提示反馈到UI
            foreach (UITipData tipData in _tips)
            {
                tipData.controller.UnChoose();
            }

            _tips[_chosen].controller.Choose();
            Debug.Log($"交互提示 | 选中id={_chosen}交互提示");
        }
    }
    /// <summary>
    /// 根据用户输入刷新选中的tip
    /// </summary>
    private void ChooseTipInput()
    {
        // 如果有可用的交互提示
        if (HaveEnabled())
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _chosen = FindLastEnabled();
                CheckChosenTip();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _chosen = FindNextEnabled();
                CheckChosenTip();
            }
        }
    }
    /// <summary>
    /// 在玩家按下按键时触发对应的函数
    /// </summary>
    private void CallTip()
    {
        if ( Input.GetKeyDown(KeyCode.F) && HaveEnabled())
        {
            Debug.Log($"触发id={_chosen}号交互提示");
            _tips[_chosen]?.call();
        }
    }

    /// <summary>
    /// 通过data移除交互提示
    /// </summary>
    /// <param name="data"></param>
    private async void Remove(UITipData data)
    {
        await UniTask.NextFrame();
        Remove(data.trans);
    }

    /// <summary>
    /// 找到下一个可用的tip
    /// </summary>
    /// <returns></returns>
    private int FindNextEnabled()
    {
        for (int i = _chosen + 1; i < _tips.Count; i++)
        {
            if (_tips[i].enabled)
            {
                return i;
            }
        }

        return FindFirstEnabled();
    }

    /// <summary>
    /// 找到第一个可用的tip
    /// </summary>
    /// <returns></returns>
    private int FindFirstEnabled()
    {
        for (int i = 0; i < _tips.Count; i++)
        {
            if (_tips[i].enabled)
            {
                return i;
            }
        }

        return 0;
    }

    /// <summary>
    /// 找到上一个交互提示
    /// </summary>
    /// <returns></returns>
    private int FindLastEnabled()
    {
        for (int i = _chosen - 1; i > 0; i--)
        {
            if (_tips[i].enabled)
            {
                return i;
            }
        }


        return FindFirstEnabled();
    }

    /// <summary>
    /// 查询是否有Enabled的交互提示
    /// </summary>
    /// <returns></returns>
    private bool HaveEnabled()
    {
        if (_tips.Count.Equals(0))
        {
            return false;
        }
        else
        {
            foreach (UITipData tipData in _tips)
            {
                if (tipData.enabled)
                {
                    return true;
                }
            }
        }

        return false;
    }
    #endregion
}
