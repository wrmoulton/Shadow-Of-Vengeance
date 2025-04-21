using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;

    void Start()
    {
        volumeSlider = GetComponent<Slider>();

        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        volumeSlider.onValueChanged.AddListener(SetVolume);
        
    }
    void SetVolume(float volume){
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();

    }
}
