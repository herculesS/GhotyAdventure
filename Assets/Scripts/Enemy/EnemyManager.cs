using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : StateMachine
{
    public float minX, maxX, minY, maxY, speed;
    [SerializeField] private GameObject _projectile;
    protected Health _health;
    protected Damage _damage;
    public GameObject Projectile { get => _projectile; }
    public Damage Damage { get => _damage; set => _damage = value; }

    protected override void Awake()
    {
        base.Awake();
        _health = GetComponent<Health>();
        _health.Initialize(1f);

        _damage = GetComponent<Damage>();
        _damage.Value = 0.25f;
        InitializeStateMachine(new EnemyIdleState(this));
    }
    void OnBecameInvisible()
    {
        pause();
    }
    void OnBecameVisible()
    {
        resume();
    }
}
