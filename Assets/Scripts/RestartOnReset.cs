using UnityEngine;

public class ResetTimeScaleOnLoad : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1f; // Ensure time always starts normally
    }
}
