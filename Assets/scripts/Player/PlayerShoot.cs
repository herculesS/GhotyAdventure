using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

	public GameObject projectile;
    private float shootDelay = 1f;
    private float currentShootDelay = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            shoot();
        }
		if (currentShootDelay > 0f) {
			currentShootDelay -= Time.deltaTime;
		}
    }

    private void shoot()
    {
        if (currentShootDelay <= 0)
        {
			GameObject obj = Instantiate(projectile, Vector3.right, Quaternion.Euler(0f, 0f, -90f));
			obj.layer = gameObject.layer;
			currentShootDelay = shootDelay;
        }
    }
}
