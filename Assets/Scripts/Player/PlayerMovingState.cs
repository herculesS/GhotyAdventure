using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerMovingState : State
{
    float _movementSpeed = 10f;
    Touch _touch;
    Vector2 _velocity;
    float previousDistanceToTouchPos;
    float currentDistanceToTouchPos;
    PlayerController _playerController;
    public PlayerMovingState(PlayerController playerController) : base(playerController)
    {
        _playerController = playerController;
    }

    public override void Start()
    {
        if (_playerController == null)
        {
            _playerController.SetState(new PlayerIdleState(_playerController));
        }
        previousDistanceToTouchPos = 0f;
        currentDistanceToTouchPos = 0f;

        _velocity = (_playerController.TouchPosition - _playerController.transform.position).normalized;
        _velocity *= _movementSpeed;
        _stateMachine.Rigidbody.velocity = _velocity;
        SetMovementFlags();

    }

    public override void Update()
    {
        if (_playerController.TouchPosition == null)
        {
            _playerController.SetState(new PlayerIdleState(_playerController));

        }
        base.Update();

        currentDistanceToTouchPos = Vector3.Distance(_playerController.TouchPosition, _playerController.transform.position);
        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            _playerController.SetState(new PlayerIdleState(_playerController));

        }
        previousDistanceToTouchPos = Vector3.Distance(_playerController.TouchPosition, _playerController.transform.position);

        SetMovementFlags();

    }

    public override void End()
    {
        _stateMachine.Rigidbody.velocity = Vector2.zero;
        _stateMachine.Animator.SetBool("movRight", false);
        _stateMachine.Animator.SetBool("movLeft", false);
        base.End();
    }

    private void SetMovementFlags()
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
