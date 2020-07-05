using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    Health PlayerHealth;

    private bool gameOver = false;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && (PlayerHealth.CurrentHealth <= Mathf.Epsilon))
        {
            Debug.Log("here");
            StartCoroutine(FadeInCR());
        }
    }

    private IEnumerator FadeInCR()
    {
        float duration = 2.0f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.g, gameOverText.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
