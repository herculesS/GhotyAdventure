
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    bool _paused = false;


    void Update()
    {
        if (InputManager.IsEscapeKeyPressed())
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (!_paused)
        {
            Time.timeScale = 0f;
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            Time.timeScale = 1f;
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        _paused = !_paused;

    }

    public  void Quit()
    {
        Application.Quit();
    }
}
