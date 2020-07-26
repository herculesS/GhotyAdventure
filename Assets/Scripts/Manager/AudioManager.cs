using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    AudioSource _musicSource;
    private void Awake()
    {

        _musicSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _musicSource.volume = AudioManager.MusicVolume;
    }

    public static float MusicVolume
    {
        get
        {
            if (PlayerPrefs.HasKey("Music"))
            {
                return PlayerPrefs.GetFloat("Music");
            }
            return 0.3f;
        }
    }

    public static float SoundsVolume
    {
        get
        {
            if (PlayerPrefs.HasKey("Sounds"))
            {
                return PlayerPrefs.GetFloat("Sounds");
            }
            return 0.3f;
        }
    }
}