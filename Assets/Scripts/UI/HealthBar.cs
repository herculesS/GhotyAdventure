using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private Health _playerHeatlh;
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = transform.parent.gameObject.GetComponent<CanvasGroup>();
    }
    void Start()
    {
        bar.fillAmount = 1f;
    }
    void Update()
    {
        if (_playerHeatlh == null) return;
        bar.fillAmount = Mathf.Lerp(bar.fillAmount, _playerHeatlh.CurrentHealthPerCent, Time.deltaTime);
    }
    public void setHealthObject(Health health)
    {
        _playerHeatlh = health;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
    }
    public void Show()
    {
        canvasGroup.alpha = 1f;
    }
}
