using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TearProjectile : Projectile
{
    Transform _tear;
    private void Start()
    {
        rb.velocity = new Vector2(getDirection().x * _speed, getDirection().y * _speed);

        _tear = transform.GetChild(0);
        if (rb.velocity.x < 0f)
        {
            var scale = _tear.localScale;
            _tear.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
    }

    protected override Vector2 getDirection()
    {
        var randomAngle = Random.Range(0f, 50f);
        var direction = base.getDirection();
        if (direction.x < 0)
        {
            randomAngle = -randomAngle;
        }
        direction = direction.Rotate(randomAngle);
        return direction;
    }



    private void FixedUpdate()
    {
        var angle = rb.velocity.Rotation() + 90f;
        var rotation = Quaternion.Euler(0f, 0f, angle);
        _tear.SetPositionAndRotation(_tear.position, rotation);
    }


}
