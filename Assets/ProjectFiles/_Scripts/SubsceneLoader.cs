using System.Collections;
using System.Collections.Generic;
using Unity.Scenes;
using UnityEngine;

public class SubsceneLoader : MonoBehaviour
{
    public static SubsceneLoader Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public SubScene[] SubScenes;
}
