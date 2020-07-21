using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void ClearProjectiles()
    {
        GameObject[] Projectiles = (GameObject.FindGameObjectsWithTag("Projectile") as GameObject[]);
        var gameObjectList = new List<GameObject>(Projectiles);

        foreach (var obj in gameObjectList)
        {
            Destroy(obj);
        }
    }
}
