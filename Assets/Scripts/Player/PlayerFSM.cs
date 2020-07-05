using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStates
{
    Idle, MovingRight, MovingLeft, MovingUp, MovingDown, Dead
}
public class PlayerFSM : MonoBehaviour
{

    private Animator animator;
    private PlayerStates state = PlayerStates.Idle;
    bool _movRight = false, _movLeft = false, _movUp = false, _movDown = false, _dead = false;

    public bool MovRight { set { _movRight = value; } }
    public bool MovLeft { set { _movLeft = value; } }
    public bool MovUp { set { _movUp = value; } }
    public bool MovDown { set { _movDown = value; } }
    public bool Dead { set { _dead = value; } }
    public PlayerStates PlayerCurrentState { get { return state; } }


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        FSM();
    }
    private void FSM()
    {
        if (_dead)
        {
            state = PlayerStates.Dead;
            return;
        }
        switch (state)
        {
            case PlayerStates.Idle:

                animator.SetBool("noInput", true);
                animator.SetBool("movRight", false);
                animator.SetBool("movLeft", false);
                if (noInput())
                {
                    state = PlayerStates.Idle;
                }
                else if (_movRight)
                {
                    state = PlayerStates.MovingRight;

                }

                else if (_movLeft)
                {
                    state = PlayerStates.MovingLeft;
                }

                else if (_movUp)
                {
                    state = PlayerStates.MovingUp;
                }
                else if (_movDown)
                {
                    state = PlayerStates.MovingDown;
                }
                break;
            case PlayerStates.MovingRight:

                animator.SetBool("noInput", false);
                animator.SetBool("movRight", true);
                animator.SetBool("movLeft", false);
                if (noInput())
                {
                    state = PlayerStates.Idle;
                }
                else if (_movLeft)
                {
                    state = PlayerStates.MovingLeft;
                }
                else if (!_movRight && _movUp)
                {
                    state = PlayerStates.MovingUp;
                }
                else if (!_movRight && _movDown)
                {
                    state = PlayerStates.MovingDown;
                }
                break;
            case PlayerStates.MovingLeft:
                animator.SetBool("noInput", false);
                animator.SetBool("movRight", false);
                animator.SetBool("movLeft", true);
                if (noInput())
                {
                    state = PlayerStates.Idle;
                }
                else if (_movRight)
                {
                    state = PlayerStates.MovingRight;
                }
                else if (!_movLeft && _movUp)
                {
                    state = PlayerStates.MovingUp;
                }
                else if (!_movLeft && _movDown)
                {
                    state = PlayerStates.MovingDown;
                }
                break;
            case PlayerStates.MovingUp:
                if (noInput())
                {
                    state = PlayerStates.Idle;
                }
                else if (_movRight)
                {
                    state = PlayerStates.MovingRight;
                }
                else if (_movLeft)
                {
                    state = PlayerStates.MovingLeft;
                }
                else if (_movUp)
                {
                    state = PlayerStates.MovingUp;
                }
                else if (_movDown)
                {
                    state = PlayerStates.MovingDown;
                }
                break;
            case PlayerStates.MovingDown:
                if (noInput())
                {
                    state = PlayerStates.Idle;
                }
                else if (_movRight)
                {
                    state = PlayerStates.MovingRight;
                }
                else if (_movLeft)
                {
                    state = PlayerStates.MovingLeft;
                }
                else if (_movUp)
                {
                    state = PlayerStates.MovingUp;
                }
                else if (_movDown)
                {
                    state = PlayerStates.MovingDown;
                }
                break;

            default:
                break;
        }
    }

    private bool noInput()
    {
        return !_movRight && !_movLeft && !_movUp && !_movDown && !_dead;
    }

    public void reset()
    {
        state = PlayerStates.Idle;
        _dead = _movRight = _movLeft = _movUp = _movDown = false;
    }
}
