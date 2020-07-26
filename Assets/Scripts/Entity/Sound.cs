using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.volume = AudioManager.SoundsVolume;
    }
}