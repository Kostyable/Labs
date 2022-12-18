using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundable // интерфейс воспроизведения звука
{
    void StartSound(AudioSource audioSource, AudioClip audioClip);
}
