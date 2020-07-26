using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : StateMachine
{

    [SerializeField] private GameObject projectile;
    private InputManager _inputManager;
    private Health _playerHealth;
    private Damage _playerDamage;
    private TakeDamage _takeDamage;
    private float _currentShootDelay = 0f;
    private float _shootDelay = 2f;
    private float _shootDirection = 1f;
    public delegate void OnPlayerShot();
    public event OnPlayerShot OnPlayerShotEvent;
    public Damage PlayerDamage { get => _playerDamage; set => _playerDamage = value; }
    public GameObject Projectile { get => projectile; set => projectile = value; }
    public float CurrentShootDelay { get => _currentShootDelay; set => _currentShootDelay = value; }
    public float ShootDirection { get => _shootDirection; set => _shootDirection = value; }
    protected override void Awake()
    {
        base.Awake();
        _playerHealth = GetComponent<Health>();
        _playerDamage = GetComponent<Damage>();
        _takeDamage = GetComponent<TakeDamage>();

    }
    void Start()
    {
        InitializeStateMachine(new PlayerIdleState(this));
        _playerHealth.Initialize(4f);
        _playerDamage.Value = 10f;
        base.resume();

    }
    protected override void Update()
    {
        if (_state is MoveToTargetPositionState state && state.TargetReached)
        {
            SetState(new PlayerIdleState(this));
        }
        if (ShouldMove)
            SetState(new PlayerMovingState(this, InputManager.GetPointerPosition()));

        if (ShouldShoot)
            Shoot();

        UpdateShootDelay();
        base.Update();
    }

    private bool ShouldShoot => _currentShootDelay <= 0 && InputManager.IsFireKeyPressed()
                                && !(_state is MoveToTargetPositionState);
    private bool ShouldMove => InputManager.PointerInputHappened()
                                && !(_state is PlayerShootState || _state is MoveToTargetPositionState);


    public void Shoot()
    {
        if (_currentShootDelay > 0) return;
        _currentShootDelay = _shootDelay;
        if (OnPlayerShotEvent != null) OnPlayerShotEvent();
        SetState(new PlayerShootState(this));
    }
    private void UpdateShootDelay()
    {
        if (_currentShootDelay > 0f)
        {
            _currentShootDelay -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy") return;

        _takeDamage.takeDamage(1f);
    }

    public void UpdateMovementDirection()
    {
        _shootDirection = (Rigidbody.velocity.x >= 0) ? 1f : -1f;
    }

    public void SetInvulnerable()
    {

    }
    public void ResetInvulnerable()
    {

    }

    public int Layer => gameObject.layer;

}
