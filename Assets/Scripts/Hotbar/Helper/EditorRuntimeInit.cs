using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorRuntimeInit : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        PlayerPrefs.SetInt("playCount", -1);

        Screen.SetResolution(1920, 1080, true);
    }
}
