using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShootState : State
{
    private PlayerController _playerController;
    public delegate void OnPlayerShot();
    public event OnPlayerShot OnPlayerShotEvent;
    public PlayerShootState(PlayerController playerController) : base(playerController)
    {
        _playerController = playerController;
    }

    public override void Start()
    {
        _playerController.Animator.SetBool("shoot", true);
        _playerController.StartCoroutine(Shoot());
        base.Start();
    }
    public override void End()
    {
        _playerController.Animator.SetBool("shoot", false);
        base.End();
    }

    public IEnumerator Shoot()
    {
        yield return null;
        var duration = _playerController.getCurrentAnimationDuration(0);
        yield return new WaitForSeconds(duration);
        InstantiateProjectile();
        _playerController.SetState(new PlayerIdleState(_playerController));
    }

    private void InstantiateProjectile()
    {
        var prefab = _playerController.Projectile;
        var position = _playerController.Position;
        var zAxisRotation = -90f;/* _playerController.ShootDirection * (-90f); */
        var rotation = Quaternion.Euler(0f, 0f, zAxisRotation);
        GameObject obj = GameObject.Instantiate(prefab, position, rotation);

        obj.layer = _playerController.Layer;
        Projectile projectile = obj.GetComponent<Projectile>();
        projectile.ProjectileDamage = _playerController.PlayerDamage.Value;
        projectile.Speed = 20f;

    }
}
