using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineProjectile : Projectile
{


    // Update is called once per frame
    void Start()
    {
        rb.velocity = new Vector2(getDirection().x * _speed, getDirection().y * _speed);
    }


}
