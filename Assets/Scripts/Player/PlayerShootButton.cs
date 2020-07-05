using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootButton : MonoBehaviour
{
    PlayerShoot _playerShoot;

    Text _FireButtonText;

    private void Awake()
    {
        _FireButtonText = GetComponent<Text>();
        _playerShoot = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>();
    }

    void Start()
    {
        _playerShoot.OnPlayerShotEvent += OnPlayerShot;
    }
    void OnPlayerShot()
    {
        _FireButtonText.text = _playerShoot.CurrentShootDelay.ToString("0.00");
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerShoot.CurrentShootDelay <= 0f)
        {
            _FireButtonText.text = "Fire";
        }
        else
        {
            _FireButtonText.text = _playerShoot.CurrentShootDelay.ToString("0.00");
        }
    }
}
