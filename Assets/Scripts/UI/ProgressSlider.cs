using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    Slider _slider;
    [SerializeField] Transform player;
    [SerializeField] Transform maxPosition;
    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        _slider.value = CurrentFill();
    }

    float CurrentFill()
    {
        var progress = player.position.x / maxPosition.position.x;
        return Mathf.Clamp(progress, 0, 9f);
    }
}
