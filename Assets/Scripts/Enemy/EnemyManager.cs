using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : StateMachine
{
    public float minX, maxX, minY, maxY, speed;
    [SerializeField] private GameObject _projectile;
    protected Health _health;
    protected Damage _damage;
    private Vector2 _initialPosition;
    public GameObject Projectile { get => _projectile; }
    public Damage Damage { get => _damage; set => _damage = value; }

    public float Speed => speed;
    public Health Health => _health;

    public Vector2 InitialPosition => _initialPosition;

    protected override void Awake()
    {
        base.Awake();
        _health = GetComponent<Health>();
        _health.Initialize(1f);

        _damage = GetComponent<Damage>();
        _damage.Value = 1f;
        InitializeStateMachine(new EnemyIdleState(this));

        _initialPosition = Position;
        pause();



    }
    protected virtual void OnBecameInvisible()
    {

        pause();
    }
    protected virtual void OnBecameVisible()
    {
        resume();
    }


}
