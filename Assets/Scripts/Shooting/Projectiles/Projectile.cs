using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float _speed = 10f;
    public float Speed { get => _speed; set => _speed = value; }
    public GameObject deathEffect;
    protected Rigidbody2D rb;
    private float _damage = 1f;
    public float ProjectileDamage { get => _damage; set => _damage = value; }
    void Awake()
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

        if (other.attachedRigidbody == null)
            return;
        TakeDamage takeDamageComponent = other.attachedRigidbody.gameObject.GetComponent<TakeDamage>();
        if (takeDamageComponent == null)
            return;

        takeDamageComponent.takeDamage(ProjectileDamage);
        Explode();
    }
    private void Explode()
    {
        GameObject ob = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(ob, 2);
    }
}
