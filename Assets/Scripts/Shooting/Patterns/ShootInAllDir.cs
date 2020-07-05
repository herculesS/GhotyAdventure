using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInAllDir : MonoBehaviour
{
    public GameObject _Projectile;
    public float _ShootDelay;
    public int _NumberOfTimesToShoot;
    public float _NumberOfProjectilesPerShot;

    private float _CurrentDelay;
    private bool _hasBegan = false;
    private float _Offset = 0f;
    private float _Damage = 0f;
    private float _CurrentOffset = 0f;
    private bool _shouldRepeat = false;
    public bool Repeat { get { return _shouldRepeat; } set { _shouldRepeat = value; } }
    public float Offset { set { _Offset = value; } }
    public float Damage { set { _Damage = value; } }

    // Use this for initialization
    void Start()
    {
        _CurrentDelay = _ShootDelay;
        _CurrentOffset = _Offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasBegan) return;
        if (_shouldRepeat) _NumberOfTimesToShoot = 1;

        shoot();

    }

    public void begin()
    {
        _hasBegan = true;
    }

    private void shoot()
    {
        if (_NumberOfTimesToShoot <= 0)
        {
            return;
        }

        if (_CurrentDelay > 0)
        {
            _CurrentDelay -= Time.deltaTime;
            return;
        }

        float angleIncrement = 360f / _NumberOfProjectilesPerShot;

        GameObject obj;
        for (int i = 0; i < _NumberOfProjectilesPerShot; i++)
        {
            obj = Instantiate(_Projectile, transform.position,
                            Quaternion.Euler(0f, 0f, i * angleIncrement + _CurrentOffset));
            
            Projectile projectile = obj.GetComponent<Projectile>();
            projectile.Speed = 7f;
            projectile.ProjectileDamage = _Damage;
            obj.layer = gameObject.layer;
        }

        _NumberOfTimesToShoot--;
        _CurrentOffset += _Offset;
        _CurrentDelay = _ShootDelay;

    }
}
