using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoBehaviourECSBridge : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 mainCameraOffset;
    public Text SwingSpeedText;
    public Image EnemyHealth;

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

    public void SetSwingText(string text)
    {
        SwingSpeedText.text = text;
    }

    public void EnemyTakeDamage(float health, float maxHp)
    {
        Vector3 tempScale = EnemyHealth.rectTransform.localScale;
        tempScale.x = health / maxHp;
    }
}
