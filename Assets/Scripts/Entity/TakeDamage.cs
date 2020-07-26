using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private Health health;
    protected bool _enabled = true;

    public bool Enabled { get => _enabled; set => _enabled = value; }
    void Start()
    {
        health = GetComponent<Health>();
    }


    public virtual void takeDamage(float damage)
    {
        if (!_enabled) return;
        health.ReduceHealthBy(damage);
    }
}
