using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthEnemyManager : EnemyManager
{

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        if (_state is EnemyBackAndForthState state)
        {
            state.pause();
        }

    }

    protected override void OnBecameVisible()
    {
        base.OnBecameVisible();
        if (_state is EnemyBackAndForthState state)
        {
            state.resume();
        }

    }

    private void Start()
    {
        _health.Initialize(1f);
        _damage.Value = 0.25f;
        InitializeStateMachine(new EnemyBackAndForthState(this));
    }

}
