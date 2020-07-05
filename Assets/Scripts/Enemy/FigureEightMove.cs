using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureEightMove : MonoBehaviour
{


    private enum EnemyState { Visible, Invisible };
    private EnemyState state;

    private Vector2 targetposition;
    private Rigidbody2D rb;

    float _speed = 5f;
    float _xscale = 10f;
    float _yscale = 5f;

    private Vector3 _pivot;
    private Vector3 _pivotOffset;
    private float _phase;
    private bool _invert = false;
    private float _2PI = Mathf.PI * 2;


    // Use this for initialization
    void Start()
    {
        state = EnemyState.Visible;
        _pivot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Visible)
        {
            move();
        }

    }

    private void move()
    {
        _pivotOffset = Vector3.right * 2 * _xscale;

        _phase += _speed * Time.deltaTime;
        if (_phase > _2PI)
        {
            _invert = !_invert;
            _phase -= _2PI;
        }
        if (_phase < 0) _phase += _2PI;

        transform.position = _pivot + (_invert ? _pivotOffset : Vector3.zero);
        Vector3 xComp = new Vector3(0, Mathf.Sin(_phase) * _yscale, 0);
        Vector3 yComp = new Vector3(Mathf.Cos(_phase) * (_invert ? -1 : 1) * _xscale, 0);

        transform.position = transform.position + xComp + yComp;
    }


    void OnBecameInvisible()
    {
        state = EnemyState.Invisible;
    }

    void OnBecameVisible()
    {
        state = EnemyState.Visible;
    }

}
