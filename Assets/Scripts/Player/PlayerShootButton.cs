using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootButton : MonoBehaviour
{
    PlayerController _playerController;
    Text _FireButtonText;
    string _originalText;
    private void Awake()
    {
        _FireButtonText = GetComponent<Text>();
        _originalText = _FireButtonText.text;
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        _playerController.OnPlayerShotEvent += OnPlayerShot;
    }
    void OnPlayerShot()
    {
        _FireButtonText.text = _playerController.CurrentShootDelay.ToString("0.00") + "s";
    }
    void Update()
    {
        if (_playerController.CurrentShootDelay <= 0f)
        {
            _FireButtonText.text = _originalText;
        }
        else
        {
            _FireButtonText.text = _playerController.CurrentShootDelay.ToString("0.00") + "s";
        }
    }
}
