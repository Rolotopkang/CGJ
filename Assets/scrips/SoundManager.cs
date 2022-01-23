using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClips;

    private void Awake() {
        instance = this;
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
