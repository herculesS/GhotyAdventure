using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemyManager : EnemyManager
{
    private void Start()
    {
        _health.Initialize(10f);
        _damage.Value = 1.25f;
        InitializeStateMachine(new EnemyStateRandomMove(this));
        Invoke(nameof(RandomShoot), 1f);
    }
    void RandomShoot()
    {
        var duration = Random.Range(2.75f, 4f);
        Invoke(nameof(RandomShoot), duration);
        if (IsPaused) return;
        SetState(new RobotEnemyShootState(this));
    }

}
