using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInAllDir : MonoBehaviour
{

    public GameObject projectile;
    public float shootFrequency;
    public int nTimes;
    public float numberOfProjectilesPerShot;
    private float currentDelay;
    private bool hasBegan = false;
    private float offset = 0f;

    private float currentOffset = 0f;


    // Use this for initialization
    void Start()
    {
        currentDelay = shootFrequency;
        currentOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBegan)
        {
            return;
        }
        shoot();

    }

    public void setOffset(float off)
    {
        offset = off;
    }

    public void begin()
    {
        hasBegan = true;
    }

    private void shoot()
    {
        if (nTimes <= 0)
        {
            return;
        }

        if (currentDelay <= 0)
        {
            float angleIncrement = 360f / numberOfProjectilesPerShot;

            GameObject obj;
            for (int i = 0; i < numberOfProjectilesPerShot; i++)
            {
                obj = Instantiate(projectile, transform.position,
                                Quaternion.Euler(0f, 0f, i * angleIncrement + currentOffset));
                obj.layer = gameObject.layer;
            }

            nTimes--;
            currentOffset += offset;
            currentDelay = shootFrequency;
        }
        currentDelay -= Time.deltaTime;


    }



}
