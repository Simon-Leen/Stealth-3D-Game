﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("AudioManager is NULL");
            }
            return _instance;
        }
    }

    public AudioSource _voiceOver;


    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip audioClip)
    {
        _voiceOver.clip = audioClip;
        _voiceOver.Play();
    }
}
