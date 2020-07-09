using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FigureEightMoveState : State
{
    EnemyManager _enemyManager;
    public FigureEightMoveState(EnemyManager enemyManager) : base(enemyManager)
    {
        _enemyManager = enemyManager;
    }
    float _speed = 5f;
    float _xscale = 10f;
    float _yscale = 5f;
    Vector3 _pivot;
    Vector3 _pivotOffset;
    float _phase;
    bool _invert = false;
    float _2PI = Mathf.PI * 2;
    public Vector3 PivotOffset { get => (_invert ? _pivotOffset : Vector3.zero); }
    public override void Start()
    {
        _pivot = _enemyManager.transform.position;
        _pivotOffset = Vector3.right * 2 * _xscale;
    }
    public override void Update()
    {
        move();
    }
    private void move()
    {
        UpdatePhase();
        _enemyManager.transform.position = _pivot + PivotOffset + Movement;
    }
    private void UpdatePhase()
    {
        _phase += _speed * Time.deltaTime;
        if (_phase > _2PI)
        {
            _invert = !_invert;
            _phase -= _2PI;
        }
        if (_phase < 0) _phase += _2PI;
    }
    private float XComp => Mathf.Cos(_phase) * (_invert ? -1 : 1) * _xscale;
    private float Ycomp => Mathf.Sin(_phase) * _yscale;
    private Vector3 Movement => new Vector3(XComp, Ycomp, 0f);
}
