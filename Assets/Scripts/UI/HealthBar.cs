using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image bar;

    [SerializeField]
    private Health _playerHeatlh;
    void Start()
    {
        bar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = Mathf.Lerp(bar.fillAmount, _playerHeatlh.CurrentHealthPerCent, Time.deltaTime);
    }
}
