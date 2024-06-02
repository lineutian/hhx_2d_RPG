using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITipData
{
    public string text { get; private set; }
    /// <summary>
    /// 交互提示触发时调用的函数
    /// </summary>
    public Action call { get; private set; }

    /// <summary>
    /// 注册交互提示的物体的transform组件，用于测量距离和检测物体是否还存在
    /// </summary>
    public Transform trans { get; private set; }
    /// <summary>
    /// 交互提示UI控制器
    /// </summary>
    public UIOnTip controller { get; private set; }

    /// <summary>
    /// 交互提示距离
    /// </summary>
    public float distance { get; private set; }
    /// <summary>
    /// 交互提示目前是否启用
    /// </summary>
    public bool enabled;
    /// <summary>
    /// 存储交互提示的数据
    /// </summary>
    /// <param name="text"></param>
    /// <param name="call">交互提示触发时调用的函数</param>
    /// <param name="trans">注册交互提示的物体的transform组件，用于测量距离和检测物体是否还存在</param>
    /// <param name="controller">交互提示UI控制器</param>
    /// <param name="distance">交互提示和玩家的距离在此值以内时显示</param>
    public UITipData(string text, Action call, Transform trans,UIOnTip controller,float distance)
    {
        this.text = text;
        this.call = call;
        this.trans = trans;
        this.controller = controller;
        this.distance = distance;
    }
}