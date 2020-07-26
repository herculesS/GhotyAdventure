using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class State
{
    protected StateMachine _stateMachine;
    protected bool Paused => _stateMachine.IsPaused;
    protected State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void End() { }

}
