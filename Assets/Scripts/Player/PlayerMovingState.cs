using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerMovingState : State
{
    float _movementSpeed = 10f;
    float _previousDistance;
    float _currentDistance;
    PlayerController _playerController;
    Vector3 _positionToMove;
    public PlayerMovingState(PlayerController playerController, Vector3 positionToMove) : base(playerController)
    {
        _playerController = playerController;
        _positionToMove = positionToMove;
    }

    public override void Start()
    {
        SetVelocity();
        _playerController.UpdateMovementDirection();
        SetPreviousDistanceToTouch();
        SetCurrentDistanceToTouch();
        SetAnimatorFlags();
    }

    private void SetVelocity()
    {
        var velocity = (_positionToMove - _playerController.transform.position).normalized;
        velocity *= _movementSpeed;
        _stateMachine.Rigidbody.velocity = velocity;
    }

    public override void Update()
    {
        base.Update();
        SetCurrentDistanceToTouch();
        if (_currentDistance > _previousDistance)
        {
            _playerController.SetState(new PlayerIdleState(_playerController));
        }
        SetPreviousDistanceToTouch();
    }

    private void SetCurrentDistanceToTouch()
    {
        _currentDistance = Vector3.Distance(_positionToMove, _playerController.transform.position);
    }

    private void SetPreviousDistanceToTouch()
    {
        _previousDistance = Vector3.Distance(_positionToMove, _playerController.transform.position);
    }

    public override void End()
    {
        _stateMachine.Rigidbody.velocity = Vector2.zero;
        _stateMachine.Animator.SetBool("movRight", false);
        _stateMachine.Animator.SetBool("movLeft", false);
        base.End();
    }

    private void SetAnimatorFlags()
    {
        if (_stateMachine.Rigidbody.velocity.x > 0f)
        {
            _stateMachine.Animator.SetBool("movRight", true);
            _stateMachine.Animator.SetBool("movLeft", false);
        }
        else if (_stateMachine.Rigidbody.velocity.x < 0f)
        {
            _stateMachine.Animator.SetBool("movRight", false);
            _stateMachine.Animator.SetBool("movLeft", true);
        }

    }
}
