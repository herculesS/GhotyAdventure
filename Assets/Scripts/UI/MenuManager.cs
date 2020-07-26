using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] CanvasGroup mainMenu;
    [SerializeField] CanvasGroup optionsMenu;

    [SerializeField] Slider musicVolume;
    [SerializeField] Slider soundsVolume;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 0.3f);
        }
        else
        {
            musicVolume.value = PlayerPrefs.GetFloat("Music");
        }
        if (!PlayerPrefs.HasKey("Sounds"))
        {
            PlayerPrefs.SetFloat("Sounds", 0.3f);
        }
        else
        {
            soundsVolume.value = PlayerPrefs.GetFloat("Sounds");
        }
    }

    void Update()
    {
        if (InputManager.IsEscapeKeyPressed() && !mainMenu.IsHidden())
            Quit();
    }
    public void BackToMainMenu()
    {
        mainMenu.Show();
        optionsMenu.Hide();
    }

    public void ShowOptions()
    {
        optionsMenu.Show();
        mainMenu.Hide();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetMusicValue(float volume)
    {
        PlayerPrefs.SetFloat("Music", volume);
        Debug.Log(PlayerPrefs.GetFloat("Music"));
    }
    public void SetSoundsValue(float volume)
    {
        PlayerPrefs.SetFloat("Sounds", volume);
        Debug.Log(volume);
    }
}