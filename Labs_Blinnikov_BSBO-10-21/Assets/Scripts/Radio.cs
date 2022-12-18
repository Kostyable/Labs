using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioClip _audioClip;

    private void Awake() // инициализация полей
    {
        _audioSource = GetComponent<AudioSource>();
        _audioClip = _audioSource.clip;
    }

    private void OnMouseDown() // срабатывание при нажатии левой кнопки мыши
    {
        StartSound(_audioSource, _audioClip);
    }

    public void StartSound(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
