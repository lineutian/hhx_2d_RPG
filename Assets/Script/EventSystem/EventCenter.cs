using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCenter
{
    private static EventCenter instance;
    // 储存所有事件
    private Dictionary<string, IEventInfo> _eventDic = new Dictionary<string, IEventInfo>();
    
    public static EventCenter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventCenter();
            }

            return instance;
        }
    }
    /// <summary>
    /// 为 _eventDic[name] 订阅 action 事件
    /// </summary>
    /// <param name="name"> _eventDic的键 </param>
    /// <param name="action"></param>
    public void AddEventListener(string name,UnityAction action)
    {
        if (_eventDic.ContainsKey(name))
        {
            (_eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            _eventDic.Add(name,new EventInfo(action));
        }
    }
    /// <summary>
    /// 触发 key值为name 的事件(即调用_eventDic[name]的所有订阅)
    /// </summary>
    /// <param name="name">key值</param>
    public void EventTrigger(string name)
    {
        if (_eventDic.ContainsKey(name))
        {
            if ((_eventDic[name] as EventInfo).actions !=null)
            {
                (_eventDic[name] as EventInfo).actions.Invoke();
            }
        }
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (_eventDic.ContainsKey(name))
        {
            (_eventDic[name] as EventInfo).actions -= action;
        }
    }

    public void Clear()
    {
        _eventDic.Clear();
    }
    
    /// <summary>
    /// 泛型方法
    /// </summary>
    public void AddEventListener<T>(string name,UnityAction<T> action)
    {
        if (_eventDic.ContainsKey(name))
        {
            (_eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            _eventDic.Add(name,new EventInfo<T>(action));
        }
    }

    public void EventTrigger<T>(string name,T Info)
    {
        if (_eventDic.ContainsKey(name))
        {
            if ((_eventDic[name] as EventInfo<T>).actions !=null)
            {
                (_eventDic[name] as EventInfo<T>).actions.Invoke(Info);
            }
        }
    }

    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (_eventDic.ContainsKey(name))
        {
            (_eventDic[name] as EventInfo<T>).actions -= action;
        }
    }
}

public interface IEventInfo
{
    
}

public class EventInfo : IEventInfo
{
    public UnityAction actions;

    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}