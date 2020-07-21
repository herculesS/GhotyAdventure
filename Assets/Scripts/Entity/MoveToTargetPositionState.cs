
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveToTargetPositionState : State
{
    private Vector3 _targetPosition;
    public MoveToTargetPositionState(StateMachine stateMachine, Vector3 position) : base(stateMachine)
    {
        _targetPosition = position;
    }
    private bool _targetReached = false;
    public bool TargetReached => _targetReached;
    private float DistanceToTarget => _stateMachine.Position.DistanceTo(_targetPosition);

    public override void Start()
    {
        var direction = _stateMachine.Position.DirectionTowards(_targetPosition);
        _stateMachine.Velocity = direction * 10f;
    }
    public override void Update()
    {
        if (TargetReached || DistanceToTarget > .5f) return;
        _stateMachine.Velocity = Vector2.zero;
        _targetReached = true;

    }
    public override void End()
    {
        _stateMachine.Velocity = Vector2.zero;
    }
}
