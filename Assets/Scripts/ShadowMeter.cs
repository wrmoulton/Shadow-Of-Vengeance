using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowMeter : MonoBehaviour
{
    [SerializeField] private Image meterImage;
    [SerializeField] private Sprite[] meterStates; // 0 = full --> 4 = empty 
    [SerializeField] private float changeSpeed = 5f;

    private float displayState;

    public void UpdateMeter(float current, float max)
    {
        float targetState = (1 - (current / max)) * (meterStates.Length - 1);
        displayState = Mathf.Lerp(displayState, targetState, changeSpeed * Time.deltaTime);
        
        int spriteIndex = Mathf.FloorToInt(displayState);
        spriteIndex = Mathf.Clamp(spriteIndex, 0, meterStates.Length - 1);
        meterImage.sprite = meterStates[spriteIndex];
    } 
}
