
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineWithNoiseProjectile : Projectile
{
    private float _noiseDelay = 0.2f;
    private float _TimePassedSinceNoiceAdded = 0f;

    void Start()
    {
        var direction = getDirection();
        rb.velocity = direction * _speed;
    }
    void Update()
    {
        if (_TimePassedSinceNoiceAdded < _noiseDelay)
        {
            _TimePassedSinceNoiceAdded += Time.deltaTime;
            return;
        }
        _TimePassedSinceNoiceAdded = 0f;
        var randomX = Random.Range(0, 500f);
        var randomY = Random.Range(0, 500f);
        var angle = Mathf.PerlinNoise(Time.time * randomX, randomY) * 90 - 45;
        var direction = getDirection();
        direction = direction.Rotate(angle);
        rb.velocity = direction * _speed;
    }
}
