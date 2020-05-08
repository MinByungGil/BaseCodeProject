using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck
{
    float _time = 0;
    public TimeCheck()
    {
        _time = Time.realtimeSinceStartup;
    }

    public void LogTime(string log)
    {
#if !REAL
        Debug.LogFormat("{0} {1}", log, Time.realtimeSinceStartup - _time);
        _time = Time.realtimeSinceStartup;
#endif
    }
}
