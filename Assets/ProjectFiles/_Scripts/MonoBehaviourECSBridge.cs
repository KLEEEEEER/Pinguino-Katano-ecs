using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourECSBridge : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 mainCameraOffset;

    #region Singleton
    private static MonoBehaviourECSBridge instanceValue;
    public static MonoBehaviourECSBridge Instance
    {
        get
        {
            return instanceValue;
        }
        set
        {
            if (instanceValue != null && value != null)
            {
                Debug.LogError("There should onlye be one instance of MonoBehaviourECSBridge");
            }
            instanceValue = value;
        }
    }
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    #endregion


}
