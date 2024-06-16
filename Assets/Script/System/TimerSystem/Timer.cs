using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    #region 属性
    /// <summary>
    /// 计时器完成后的委托
    /// </summary>
    private Action OnFinished;

    private float mFinishTime;
    private float mDelayTime;
    
    /// <summary>
    /// 是否循环
    /// </summary>
    private bool mLoop;
    
    public bool IsFinish { get; private set; }

    public void Setup(Action onFinished, float delayTime, bool loop = false)
    {
        OnFinished = onFinished;
        mFinishTime = Time.time+delayTime;
        mDelayTime = delayTime;
        mLoop= loop;
        IsFinish = false;
    }

    public void Stop() => IsFinish = true;

    public void Update()
    {
        if(IsFinish)return;
        if(Time.time<mFinishTime)return;
        if(!mLoop) Stop();
        else mFinishTime = Time.time+mDelayTime;
        OnFinished?.Invoke();
    }
    #endregion
}
