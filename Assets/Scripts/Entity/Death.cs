using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	private Health health;
	public GameObject deathEffect;
	void Start () {
		health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health.CurrentHealth <= 0f) {
			die();
		}
	}

	protected virtual void die() {
		GameObject obj = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Destroy(obj, 2f);
	}
}
