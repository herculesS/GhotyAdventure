using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{

    public float minX, maxX, minY, maxY, speed;

    private enum EnemyState { Visible, Invisible };
    private EnemyState state;

    private Vector2 targetposition;
    private Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        targetposition = getRandomPos();
        rb = GetComponent<Rigidbody2D>();
        state = EnemyState.Visible;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Visible)
        {
            move();
        }

    }


    private float distanceToTarget()
    {
        return (targetposition - (Vector2)transform.position).magnitude;
    }

    private Vector2 targetDirection()
    {
        return (targetposition - (Vector2)transform.position).normalized;
    }

    private void move()
    {

        if (distanceToTarget() > .1f)
        {
            rb.velocity = new Vector2(targetDirection().x * speed, targetDirection().y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
            targetposition = getRandomPos();
        }
    }

    Vector2 getRandomPos()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);



        return new Vector2(randomX, randomY);
    }


    void OnBecameInvisible()
    {
        state = EnemyState.Invisible;
    }

    /// <summary>
    /// OnBecameVisible is called when the renderer became visible by any camera.
    /// </summary>
    void OnBecameVisible()
    {
        state = EnemyState.Visible;
    }


}
