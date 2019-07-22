using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;


public abstract class JobHandler<T>
    where T : struct, IJob
{

    protected T m_currentJob;
    protected JobHandle m_currentHandle;

    protected bool m_scheduled = false;

    public void Schedule( float delta)
    {
        if (m_scheduled) { return; }
        m_scheduled = true;

        m_currentJob = new T();
        Prepare(ref m_currentJob, delta);

        m_currentHandle = m_currentJob.Schedule();
        
    }

    protected abstract void Prepare(ref T job, float delta);

    public void Complete()
    {
        if (!m_scheduled) { return; }

        m_currentHandle.Complete();

        m_scheduled = false;

        Apply(ref m_currentJob);

    }

    protected abstract void Apply(ref T job);
    

}
