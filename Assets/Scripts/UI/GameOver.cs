using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] Health PlayerHealth;
    [SerializeField] AdsManager adsManager;
    [SerializeField] Button adButton;

    private bool gameOver = false;

    
  
    void Start()
    {
        adsManager.OnVideoWatched += HandleVideoWatched;
    }

    void HandleVideoWatched()
    {
        PlayerHealth.RestoreHealthBy(2f);
        canvasGroup.alpha = 0f;
        Time.timeScale = 1f;

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Destroy(adButton);
    }

    void Update()
    {
        if (!gameOver && (PlayerHealth.CurrentHealth <= Mathf.Epsilon))
        {
            StartCoroutine(FadeInCR());
        }
    }

    private IEnumerator FadeInCR()
    {
        float duration = 2.0f;
        float currentTime = 0f;
        /* while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            canvasGroup.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        } */

        canvasGroup.alpha = 1f;
        Time.timeScale = 0f;

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        yield break;
    }
}
