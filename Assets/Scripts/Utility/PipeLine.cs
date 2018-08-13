﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipeLine : MonoBehaviour {
    public abstract void OnPreRenderEvent();
    [System.NonSerialized]
    public int currentIndex;

    protected virtual void OnEnable()
    {
        currentIndex = PipelineBase.onPreRenderEvents.Count;
        PipelineBase.onPreRenderEvents.Add(this);
    }

    protected virtual void OnDisable()
    {
        int last = PipelineBase.onPreRenderEvents.Count - 1;
        PipelineBase.onPreRenderEvents[currentIndex] = PipelineBase.onPreRenderEvents[last];
        PipelineBase.onPreRenderEvents.RemoveAt(last);
    }
}
