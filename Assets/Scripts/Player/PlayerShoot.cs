using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public delegate void OnPlayerShot();
    public event OnPlayerShot OnPlayerShotEvent;
    public GameObject _Projectile;
    private Damage _playerDamage;
    private float _ShootDelay = 4f;
    private float _CurrentShootDelay = 0f;
    public float CurrentShootDelay { get { return _CurrentShootDelay; } }

    private void Awake()
    {
        _playerDamage = GetComponent<Damage>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shoot();
        }
        if (_CurrentShootDelay > 0f)
        {
            _CurrentShootDelay -= Time.deltaTime;
        }
    }

    public void shoot()
    {
        if (_CurrentShootDelay > 0) return;

        GameObject obj = Instantiate(_Projectile, transform.position, Quaternion.Euler(0f, 0f, -90f));
        obj.layer = gameObject.layer;
        Projectile projectile = obj.GetComponent<Projectile>();
        projectile.ProjectileDamage = _playerDamage.Value;
        projectile.Speed = 20f;
        _CurrentShootDelay = _ShootDelay;

        if (OnPlayerShotEvent != null) OnPlayerShotEvent();
    }


}
