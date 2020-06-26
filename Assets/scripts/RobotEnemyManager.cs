using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemyManager : MonoBehaviour
{

    ShootInAllDir projPattern;

    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
        health.CurrentHealth = 10f;
        health.MaxHealth = 10f;
        projPattern = GetComponent<ShootInAllDir>();
        projPattern.setOffset(15f);
        Invoke("beginPattern", 2f);
    }

    void beginPattern()
    {
        projPattern.begin();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
