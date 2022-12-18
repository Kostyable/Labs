using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandpa : MonoBehaviour, ISoundable
{
    private AudioSource _audioSource;
    private AudioClip _audioClip;

    private void Awake() // инициализация полей и запуск метода
    {
        _audioSource = GetComponent<AudioSource>();
        _audioClip = _audioSource.clip;
        StartSound(_audioSource, _audioClip);
    }

    public void StartSound(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.Play();
    }
}
