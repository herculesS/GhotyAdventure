using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkullBossDeath : BossState
{
    SkullBossManager _bossManager;
    public SkullBossDeath(EnemyManager enemyManager) : base(enemyManager)
    {
        _bossManager = enemyManager as SkullBossManager;
    }

    public override void Start()
    {
        _bossManager.Animator.SetBool("dead", true);
        _bossManager.StartCoroutine(Die());
        base.Start();
    }

    IEnumerator Die()
    {
        GameManager.ClearProjectiles();
        yield return null;
        var duration = _bossManager.getCurrentAnimationDuration(0);
        yield return new WaitForSeconds(duration);
        _bossManager.OnDeath();

        Object.Destroy(_bossManager.gameObject);

    }
}
