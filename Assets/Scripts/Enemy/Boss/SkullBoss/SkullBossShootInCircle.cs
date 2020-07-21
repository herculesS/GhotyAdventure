
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkullBossShootInCircle : BossState
{
    Transform _player;
    SkullBossManager _bossManager;
    private float _shootForSeconds = 3f;
    private int _NumberOfProjectilesPerShot = 11;
    private float _delayBetweenShots = 0.4f;
    public SkullBossShootInCircle(EnemyManager enemyManager) : base(enemyManager)
    {
        _bossManager = enemyManager as SkullBossManager;
    }

    public override void Start()
    {
        base.Start();
        _bossManager.Animator.SetBool("shoot", true);
        if (_player == null)
            _player = GameObject.FindWithTag("Player").transform;
        _bossManager.StartCoroutine(Shoot());

    }
    public override void End()
    {
        _bossManager.Animator.SetBool("shoot", false);
    }

    public IEnumerator Shoot()
    {
        yield return null;
        var duration = _bossManager.getCurrentAnimationDuration(0);
        yield return new WaitForSeconds(duration);

        while (_bossManager.IsPaused)
        {
            yield return null;
        }
        var timeSinceShootingStarted = 0f;

        while (timeSinceShootingStarted < _shootForSeconds)
        {
            float angleIncrement = 360f / _NumberOfProjectilesPerShot;
            for (int i = 0; i < _NumberOfProjectilesPerShot; i++)
            {
                var obj = GameObject.Instantiate(_bossManager.Projectile, _bossManager.Position,
                                    Quaternion.Euler(0f, 0f, i * angleIncrement));
                Projectile projectile = obj.GetComponent<Projectile>();
                projectile.Speed = 7f;
                projectile.ProjectileDamage = _bossManager.Damage.Value;
                obj.layer = _bossManager.gameObject.layer;
            }

            yield return new WaitForSeconds(_delayBetweenShots);
            timeSinceShootingStarted += _delayBetweenShots;
        }



        IsDone = true;

    }
    private void InstantiateProjectileObject()
    {
        var projectile = _bossManager.Projectile;
        var position = _bossManager.Position;
        var rotation = Quaternion.Euler(0f, 0f, rotationToTarget());
        var obj = GameObject.Instantiate(projectile, position, rotation);
        InitializeProjectileObject(obj);
    }
    private void InitializeProjectileObject(GameObject obj)
    {
        Projectile projectile = obj.GetComponent<Projectile>();
        projectile.Speed = 15f;
        projectile.ProjectileDamage = _bossManager.Damage.Value;
        obj.layer = _bossManager.gameObject.layer;
    }

    public float rotationToTarget()
    {
        Vector2 direction = _bossManager.Position.DirectionTowards(_player.position);
        var rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        return rotation;
    }
}