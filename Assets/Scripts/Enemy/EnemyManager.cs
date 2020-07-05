using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    protected Health _health;
    protected Damage _damage;

    protected virtual void Awake()
    {
        _health = GetComponent<Health>();
        _health.Initialize(1f);

        _damage = GetComponent<Damage>();
        _damage.Value = 0.25f;
    }

}
