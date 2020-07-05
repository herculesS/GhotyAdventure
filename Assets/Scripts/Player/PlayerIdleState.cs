using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerIdleState : State
{
    public PlayerIdleState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Start()
    {
        _stateMachine.Animator.SetBool("noInput", true);
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void End()
    {
         _stateMachine.Animator.SetBool("noInput", false);
        base.End();
    }

}
