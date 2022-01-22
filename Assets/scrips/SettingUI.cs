using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour {
    
    public GameObject SettingUIObject;
    public GameObject SettingButton;
    public Slider SoundSlider;
    public Slider MusicSlider;
    public AudioMixer SoundMixer;
    public AudioMixer MusicMixer;
    public Toggle MuteToggle;

    private bool isMute =false;


    private void Update() {
        isMute = MuteToggle.isOn;
        if (!isMute) {
            SoundMixer.SetFloat("Sound", SoundSlider.value);
            MusicMixer.SetFloat("Music", MusicSlider.value);
        } else {
            SoundMixer.SetFloat("Sound", -80);
            MusicMixer.SetFloat("Music", -80);
        }
    }
    
    public void CloseSettingUI() {
        Time.timeScale = 1;
        SettingUIObject.SetActive(false);
        SettingButton.SetActive(true);
        SoundManager.instance.CloseUI();
    }
    
    public void OpenSettingUI() {
        Time.timeScale = 0;
        SettingUIObject.SetActive(true);
        SettingButton.SetActive(false);
        SoundManager.instance.OpenUI();
    }
}
