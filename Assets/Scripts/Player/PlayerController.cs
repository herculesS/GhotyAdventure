using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StateMachine
{
    private Health _playerHealth;
    private Damage _playerDamage;
    private TakeDamage _takeDamage;
    private Vector3 _touchPosition;

    public Vector3 TouchPosition { get { return _touchPosition; } }

    protected override void Awake()
    {
        base.Awake();
        _playerHealth = GetComponent<Health>();
        _playerDamage = GetComponent<Damage>();
        _takeDamage = GetComponent<TakeDamage>();
    }

    void Start()
    {
        SetState(new PlayerIdleState(this));
        if (_playerHealth != null)
        {
            _playerHealth.Initialize(4f);
        }

        if (_playerDamage != null)
        {
            _playerDamage.Value = 10f;
        }
        //InvokeRepeating("debugHealth", 2f, 0.3f);
    }

    protected override void Update()
    {
        if (TouchHappened())
            HandleTouch();

        base.Update();
    }

    private void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                _touchPosition.z = 0;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            _touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _touchPosition.z = 0;
        }
        SetState(new PlayerMovingState(this));
    }

    private bool TouchHappened()
    {
        if (IsPointerOverGameObject() || Input.touchCount == 0 || !Input.GetMouseButtonDown(0))
        {
            return false;
        }
        return true;
    }
    public static bool IsPointerOverGameObject()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }
    public void debugHealth()
    {
        Debug.Log("Player health: " + _playerHealth.CurrentHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            _takeDamage.takeDamage(.25f);
    }



}
