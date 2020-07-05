using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemyManager : EnemyManager
{
    private ShootInAllDir _AllDirProjectilePattern;

    protected override void Awake()
    {
        base.Awake();
        _AllDirProjectilePattern = GetComponent<ShootInAllDir>();
    }

    private void Start()
    {
        _health.Initialize(10f);
        _damage.Value = 0.25f;
        _AllDirProjectilePattern.Offset = 15f;
        _AllDirProjectilePattern.Damage = _damage.Value;
        _AllDirProjectilePattern.Repeat = true;
        Invoke("beginPattern", 2f);
    }

    private void beginPattern()
    {
        _AllDirProjectilePattern.begin();
    }

}
