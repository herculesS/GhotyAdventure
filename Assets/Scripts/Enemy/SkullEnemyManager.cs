using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullEnemyManager : EnemyManager
{
    void Start()
    {
        _health.Initialize(1f);
        InitializeStateMachine(new FigureEightMoveState(this));
        var duration = Random.Range(5f, 7f);
        Invoke(nameof(RandomShoot), duration);
    }
    void RandomShoot()
    {
        var duration = Random.Range(5f, 7f);
        Invoke(nameof(RandomShoot), duration);
        if (IsPaused) return;
        SetState(new SkullEnemyShootState(this));

    }

}
