using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour, ISoundable
{
    private AudioSource _audioSource;
    private AudioClip _audioClip;

    private void Awake() // инициализация полей
    {
        _audioSource = GetComponent<AudioSource>();
        _audioClip = _audioSource.clip;
    }
    private void Update()
    {
        StartSound(_audioSource, _audioClip);
    }

    public void StartSound(AudioSource audioSource, AudioClip audioClip) // срабатывание при нажатии клавиши E
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
