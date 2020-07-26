using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackAndForthState : State
{
    EnemyManager _enemyManager;
    Vector3 _initialPosition;
    bool _IsDirectionReverse = true;
    float XValueOfVelocity => _IsDirectionReverse ? -_enemyManager.Speed : _enemyManager.Speed;
    Vector2 Velocity => new Vector2(XValueOfVelocity, 0);

    bool ShouldReverseDirection => Mathf.Abs(_initialPosition.x - _enemyManager.Position.x) > 20f;



    public EnemyBackAndForthState(EnemyManager enemyManager) : base(enemyManager)
    {
        _enemyManager = enemyManager;
    }

    public override void Start()
    {
        _initialPosition = _enemyManager.Position;
        if (_enemyManager.IsPaused)
        {
            pause();
        }
        else
        {
            resume();
        }
    }
    public override void Update()
    {
        if (!ShouldReverseDirection) return;

        _IsDirectionReverse = !_IsDirectionReverse;
        _enemyManager.Rigidbody.velocity = Velocity;
        _initialPosition = _enemyManager.Position;

    }
    public override void End()
    {
        _enemyManager.Rigidbody.velocity = Vector2.zero;
    }

    public void pause()
    {
        _enemyManager.Velocity = Vector2.zero;
    }

    public void resume()
    {
        _enemyManager.Velocity = Velocity;
    }
}
