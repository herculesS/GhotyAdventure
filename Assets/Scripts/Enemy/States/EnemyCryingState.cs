using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCryingState : State
{
    LaughingEnemyManager _laughingEnemyManager;
    float _delayBetweenShots = .8f;
    public EnemyCryingState(EnemyManager enemyManager) : base(enemyManager)
    {
        _laughingEnemyManager = enemyManager as LaughingEnemyManager;
    }

    public override void End()
    {
        base.End();
    }


    public override void Start()
    {
        base.Start();
        _laughingEnemyManager.StartCoroutine(Cry());
    }




    private IEnumerator Cry()
    {
        yield return null;
        var duration = _laughingEnemyManager.getCurrentAnimationDuration(0);
        yield return new WaitForSeconds(duration);
        while (true)
        {
            while (Paused)
            {
                yield return null;
            }

            InstantiateProjectileObject();
            yield return new WaitForSeconds(_delayBetweenShots);
        }


    }
    private void InstantiateProjectileObject()
    {
        var projectile = _laughingEnemyManager.Projectile;
        var position = _laughingEnemyManager.RightEye;
        var rotation = Quaternion.Euler(0f, 0f, -90f);
        var obj = GameObject.Instantiate(projectile, position, rotation);
        InitializeProjectileObject(obj);

        position = _laughingEnemyManager.LeftEye;
        rotation = Quaternion.Euler(0f, 0f, -270f);
        obj = GameObject.Instantiate(projectile, position, rotation);
        InitializeProjectileObject(obj);
    }
    private void InitializeProjectileObject(GameObject obj)
    {
        Projectile projectile = obj.GetComponent<Projectile>();
        projectile.Speed = 20f;
        projectile.ProjectileDamage = _laughingEnemyManager.Damage.Value;
        obj.layer = _laughingEnemyManager.gameObject.layer;
    }
}
