using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkullEnemyShootState : State
{
    EnemyManager _enemyManager;
    Transform _player;
    int _numberOfShots = 3;
    float _delayBetweenShots = .2f;
    bool Paused => _stateMachine.IsPaused;
    public SkullEnemyShootState(EnemyManager enemyManager) : base(enemyManager)
    {
        _enemyManager = enemyManager;
    }

    public override void Start()
    {
        _enemyManager.Animator.SetBool("shoot", true);
        _player = GameObject.FindWithTag("Player").transform;
        _enemyManager.StartCoroutine(Shoot());
    }
    public override void End()
    {
        _enemyManager.Animator.SetBool("shoot", false);
    }

    public IEnumerator Shoot()
    {
        yield return null;
        var duration = _enemyManager.getCurrentAnimationDuration(0);
        yield return new WaitForSeconds(duration);

        while (Paused)
        {
            yield return null;
        }
        for (int i = 0; i < _numberOfShots; i++)
        {
            InstantiateProjectileObject();
            yield return new WaitForSeconds(_delayBetweenShots);
        }
        _enemyManager.GoBack();

    }
    private void InstantiateProjectileObject()
    {
        var projectile = _enemyManager.Projectile;
        var position = _enemyManager.transform.position;
        var rotation = Quaternion.Euler(0f, 0f, rotationToTarget());
        var obj = GameObject.Instantiate(projectile, position, rotation);
        InitializeProjectileObject(obj);
    }
    private void InitializeProjectileObject(GameObject obj)
    {
        Projectile projectile = obj.GetComponent<Projectile>();
        projectile.Speed = 50f;
        projectile.ProjectileDamage = _enemyManager.Damage.Value;
        obj.layer = _enemyManager.gameObject.layer;
    }

    public float rotationToTarget()
    {
        Vector2 direction = (_player.position - _enemyManager.transform.position).normalized;
        var rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        return rotation;
    }
}
