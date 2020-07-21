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

    float XMin => Mathf.Clamp(_enemyManager.InitialPosition.x - 10f, 0, 500f);
    float XMax => Mathf.Clamp(_enemyManager.InitialPosition.x + 10f, 0, 500f);
    float YMin => Mathf.Clamp(_enemyManager.InitialPosition.y - 10f, -10f, 10f);
    float YMax => Mathf.Clamp(_enemyManager.InitialPosition.y + 10f, -10f, 10f);
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
        float randomX = Random.Range(XMin, XMax);
        float randomY = Random.Range(YMin, YMax);
        return new Vector2(randomX, randomY);
    }
    private float DistanceToRandomPosition => _randomPosition.DistanceTo((Vector2)_stateMachine.Position);
    private Vector2 RandomPositionDirection => _stateMachine.Position.DirectionTowards(_randomPosition);
    Vector2 VelocityTowardsRandomPosition => new Vector2(RandomPositionDirection.x, RandomPositionDirection.y) * _enemyManager.speed;
}
