using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossDashFowardState : BossState
{
    SkullBossManager _skullBossManager;
    bool _dashing = true;
    bool _goingBack = false;
    public BossDashFowardState(EnemyManager enemyManager) : base(enemyManager)
    {
        _skullBossManager = enemyManager as SkullBossManager;
    }

    public override void Start()
    {
        _skullBossManager.Velocity = Vector2.left * _skullBossManager.Speed * 3f;
        _dashing = true;
        _goingBack = false;
        base.Start();
    }

    public override void Update()
    {
        if (IsDone) return;
        if (!_dashing && _skullBossManager.DistanceToStartPosition() < .5f)
        {
            Debug.Log("" + _skullBossManager.DistanceToStartPosition());
            IsDone = true;
            _skullBossManager.Velocity = Vector2.zero;
            return;
        }

        if (_dashing && _skullBossManager.DistanceToStartPosition() < 100f) return;
        if (_goingBack) return;
        _dashing = false;
        _skullBossManager.Position = new Vector2(_skullBossManager.StartPosition.x + 20f, _skullBossManager.StartPosition.y);
        var direction = _skullBossManager.DirectionTowardsStartPosition();
        _skullBossManager.Velocity = direction * _bossManager.Speed;
        _goingBack = true;
        Debug.Log(direction.x + " " + direction.y);
    }

    public override void End()
    {
        _skullBossManager.Velocity = Vector2.zero;
    }

}
