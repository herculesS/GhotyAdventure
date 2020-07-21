using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform starPoint;
    [SerializeField] private Transform PlayerStartPoint;
    [SerializeField] private GameObject boss;
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameWon gameWon;
    private EnemyManager _enemyManager;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        DestroyAllUnnecessaryObjects();
        InstatiateBoss();
        _enemyManager.GoToPosition(starPoint.position);
        player.GoToPosition(PlayerStartPoint.position);
        SetBossFightCamera();
        SetBossHealthBarUI();
        Destroy(gameObject);
    }

    private void InstatiateBoss()
    {
        var obj = Instantiate(boss, spawnPoint.position, Quaternion.identity);
        _enemyManager = obj.GetComponent<EnemyManager>();

        if (_enemyManager is SkullBossManager bossManager)
        {
            bossManager.OnSkullBossDeath += gameWon.Show;
        }
    }

    private void SetBossHealthBarUI()
    {
        healthBar.setHealthObject(_enemyManager.Health);
        healthBar.Show();
    }

    private void SetBossFightCamera()
    {
        var cameraPosition = transform.position;
        cameraPosition.z = -10;
        cameraMovement.SetBossFightPosition(cameraPosition);
    }

    public void DestroyAllUnnecessaryObjects()
    {
        GameObject[] Enemies = (GameObject.FindGameObjectsWithTag("Enemy") as GameObject[]);
        GameObject[] Projectiles = (GameObject.FindGameObjectsWithTag("Projectile") as GameObject[]);
        var gameObjectList = new List<GameObject>(Enemies);
        gameObjectList.AddRange(Projectiles);

        foreach (var obj in gameObjectList)
        {
            Destroy(obj);
        }
    }

}
