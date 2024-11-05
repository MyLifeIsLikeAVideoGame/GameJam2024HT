using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public UnityEngine.UI.Slider volumeSlider;
    public AudioListener audioListener;

    // Start is called before the first frame update
    void Start()
    {
        audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }
    }

    private void Update()
    {
        ChangeVolume();
    }


    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;  
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
