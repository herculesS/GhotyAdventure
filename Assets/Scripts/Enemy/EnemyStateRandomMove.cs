using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyStateRandomMove : State
{
    EnemyManager _enemyManager;
    public EnemyStateRandomMove(EnemyManager enemyManager) : base(enemyManager)
    {
        _enemyManager = enemyManager;
    }
    Vector2 _randomPosition;
    public override void Start()
    {
        _randomPosition = GetRandomPos();
    }
    public override void Update()
    {
        if (DistanceToRandomPosition > .5f)
        {
            _stateMachine.Rigidbody.velocity = VelocityTowardsRandomPosition;
        }
        else
        {
            _stateMachine.Rigidbody.velocity = Vector2.zero;
            _randomPosition = GetRandomPos();
        }
    }
    public override void End()
    {
        _stateMachine.Rigidbody.velocity = Vector2.zero;
    }
    Vector2 GetRandomPos()
    {
        float randomX = Random.Range(_enemyManager.minX, _enemyManager.maxX);
        float randomY = Random.Range(_enemyManager.minY, _enemyManager.maxY);
        return new Vector2(randomX, randomY);
    }
    private float DistanceToRandomPosition => (_randomPosition - (Vector2)_stateMachine.Rigidbody.transform.position).magnitude;
    private Vector2 RandomPositionDirection => (_randomPosition - (Vector2)_stateMachine.Rigidbody.transform.position).normalized;
    Vector2 VelocityTowardsRandomPosition => new Vector2(RandomPositionDirection.x, RandomPositionDirection.y) * _enemyManager.speed;
}
