using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : Singleton<TimerManager>
{
    private List<Timer> mUpdateList = new List<Timer>();
    private Queue<Timer> mAvailableQueue = new Queue<Timer>();

    public Timer AddTimer(Action onFinished, float delayTime, bool isLoop = false)
    {
        var timer=mAvailableQueue.Count==0?new Timer():mAvailableQueue.Dequeue();
        timer.Setup(onFinished,delayTime,isLoop);
        mUpdateList.Add(timer);
        return timer;
    }

    public void Update()
    {
        if(mUpdateList.Count==0)return;
        for (int i = 0; i < mUpdateList.Count; i++)
        {
            if (mUpdateList[i].IsFinish)
            {
                mUpdateList.RemoveAt(i);
                mAvailableQueue.Enqueue(mUpdateList[i]);
                continue;
            }
            mUpdateList[i].Update();
        }
    }
}
