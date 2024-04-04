using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    
    void Start()
    {
        if(PlayerPrefs.HasKey("soundVolume")) // If key soundVolume exists, load saved value
        {
            Load();
        }
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 1); // Set volume to max
            //Load();
        }
    }

    public void ChangeVolume() // When volume value is changed, save that value
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value); // .SetFloat sets value
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume"); // .GetFloat retrieves value
    }
}
