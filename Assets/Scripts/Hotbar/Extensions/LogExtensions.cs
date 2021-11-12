using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogExtensions
{
    public static void Log(this object value)
    {
#if UNITY_EDITOR
        Debug.Log(value);
#endif
    }

    public static void LogWarning(this object value)
    {
#if UNITY_EDITOR
        Debug.LogWarning(value);
#endif
    }

    public static void LogError(this object value)
    {
#if UNITY_EDITOR
        Debug.LogError(value);
#endif
    }
}
