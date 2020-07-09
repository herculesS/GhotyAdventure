using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotEnemyShootState : State
{
    EnemyManager _enemyManager;
    int _NumberOfProjectilesPerShot = 10;
    public RobotEnemyShootState(EnemyManager enemyManager) : base(enemyManager)
    {
        _enemyManager = enemyManager;
    }

    public override void Start()
    {
        _enemyManager.Animator.SetBool("shoot", true);
        _enemyManager.StartCoroutine(Shoot());
    }
    public override void End()
    {
        _enemyManager.Animator.SetBool("shoot", false);
    }

    public IEnumerator Shoot()
    {
        yield return null;
        var duration = _enemyManager.Animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(duration);
        float angleIncrement = 360f / _NumberOfProjectilesPerShot;
        for (int i = 0; i < _NumberOfProjectilesPerShot; i++)
        {
            var obj = GameObject.Instantiate(_enemyManager.Projectile, _enemyManager.transform.position,
                                Quaternion.Euler(0f, 0f, i * angleIncrement));

            Projectile projectile = obj.GetComponent<Projectile>();
            projectile.Speed = 7f;
            projectile.ProjectileDamage = _enemyManager.Damage.Value;
            obj.layer = _enemyManager.gameObject.layer;
        }
        _enemyManager.SetState(new EnemyStateRandomMove(_enemyManager));
    }
}
