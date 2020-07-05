using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private Health health;
    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
    }


    public virtual void takeDamage(float damage)
    {
        health.ReduceHealthBy(damage);
    }
}
