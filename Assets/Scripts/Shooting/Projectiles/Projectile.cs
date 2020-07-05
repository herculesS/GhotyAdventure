using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{



    protected float _speed = 10f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public GameObject deathEffect;
    protected Rigidbody2D rb;

    protected float _damage = 1f;

    public float ProjectileDamage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    protected virtual Vector2 getDirection()
    {
        return transform.up.normalized;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

        /* 
            If it hits a something with rigidbody,
             checks if object hit has health and should be damaged
        */
        if (other.attachedRigidbody != null)
        {
            TakeDamage takeDamageComponent = other.attachedRigidbody.gameObject.GetComponent<TakeDamage>();
            if (takeDamageComponent != null)
            {
                takeDamageComponent.takeDamage(ProjectileDamage);
            }
        }

        GameObject ob = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(ob, 2);

    }
}
