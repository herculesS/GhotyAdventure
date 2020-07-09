using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootButton : MonoBehaviour
{
    PlayerController _playerController;
    Text _FireButtonText;
    private void Awake()
    {
        _FireButtonText = GetComponent<Text>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        _playerController.OnPlayerShotEvent += OnPlayerShot;
    }
    void OnPlayerShot()
    {
        _FireButtonText.text = _playerController.CurrentShootDelay.ToString("0.00");
    }
    void Update()
    {
        if (_playerController.CurrentShootDelay <= 0f)
        {
            _FireButtonText.text = "Fire";
        }
        else
        {
            _FireButtonText.text = _playerController.CurrentShootDelay.ToString("0.00");
        }
    }
}
