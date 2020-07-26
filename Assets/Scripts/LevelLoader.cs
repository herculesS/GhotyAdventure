using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] AdsManager adsManager;
    void Awake()
    {
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (adsManager != null) ;
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
    }
    public void play()
    {
        Load(1);
    }

    public void LoadBossFight(int scene)
    {
        Load(2);
    }

    public void BackToMainMenu()
    {
        Load(0);
    }

    private void Load(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
}
