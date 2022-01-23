using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {    
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private  List<AudioClip> audioClips;

    private void Awake() {
    }

    public void OpenUI() {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    
    public void CloseUI() {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }       
}
