using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Viewer
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class UIOnTip : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    /// <summary>
    /// 表示这个交互提示被选中的标志
    /// </summary>
    [SerializeField] private Image chooseIcon;

    private CanvasGroup _canvasGroup;
    private UITipData _data;
    private bool _chosen;
    #region api
    /// <summary>
    /// 初始化这个交互提示
    /// </summary>
    /// <param name="data">交互提示信息</param>
    /// <returns></returns>
    public UIOnTip Setup(UITipData data)
    {
        _data = data;
        this.text.text = data.text;
        _canvasGroup = GetComponent<CanvasGroup>();
        _data.enabled = true;
        Debug.Log($"交互提示{text.text}初始化完成");
        return this;
    }

    public UIOnTip SetTip(UITipData data)
    {
        _data = data;
        this.text.text = data.text;
        _canvasGroup = GetComponent<CanvasGroup>();
        return this;
    }
    /// <summary>
    /// 选择这个交互提示
    /// </summary>
    public void Choose()
    {
        if (!_chosen)
        {
            chooseIcon.DOFade(0.8f, 0.2f);
            _chosen = true;
        }

    }
    /// <summary>
    /// 取消选择这个交互提示
    /// </summary>
    public void UnChoose()
    {
        if (_chosen)
        {
            chooseIcon.DOFade(0.13f, 0.2f);
            _chosen = false;
        }
    }
    /// <summary>
    /// 启用这个交互提示
    /// </summary>
    public void Enable()
    {
        _data.enabled = true;
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, 0.4f);
    }
    /// <summary>
    /// 禁用这个交互提示
    /// </summary>
    public async void Disable()
    {
        _data.enabled = false;
        Debug.Log("禁用交互提示");
        _canvasGroup.DOFade(0, 0.4f);
        await UniTask.Delay(200);
        gameObject.SetActive(false);
    }

    #endregion

    #region mono

    private async void Awake()
    {
        
    }

    #endregion
}