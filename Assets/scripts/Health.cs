using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private float _maxHealth = 1f;
    private float _currentHealth = 0f;

    public float MaxHealth
    {
        get { return _maxHealth; }
        set
        {
            _maxHealth = value > 0f ? value : 1f;
        }
    }
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value > 0f ? value : 0f;
        }

    }

    public void ReduceHealthBy(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0f, _maxHealth);
    }

    public void RestoreHealthBy(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0f, _maxHealth);
    }


}
