using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineProjectile : MonoBehaviour
{

    public float speed;
    
    public GameObject deathEffect;
    private Rigidbody2D rb;

    private float _damage = 1f;

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

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(getDirection().x * speed, getDirection().y * speed + 2 * Mathf.Sin(50 * Time.deltaTime));

    }

    Vector2 getDirection()
    {
        return transform.up.normalized;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /* 
            If it hits a something with rigidbody,
             checks if object hit has health and should be damaged
        */
        if (other.attachedRigidbody != null)
        {
            Health targetHeath = other.attachedRigidbody.gameObject.GetComponent<Health>();
            if (targetHeath != null)
            {
                targetHeath.ReduceHealthBy(ProjectileDamage);
            }
        }

        GameObject ob = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(ob, 2);

    }
}
