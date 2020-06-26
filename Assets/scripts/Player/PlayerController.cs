using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Health playerHealth;
	Damage playerDamage;



	void Start () {
		
		playerHealth = GetComponent<Health> ();
		if(playerHealth != null) {
			playerHealth.MaxHealth = 4f;
			playerHealth.CurrentHealth = 4f;
		}
		playerDamage = GetComponent<Damage>();
		if (playerDamage != null) {
			playerDamage.Value = 10f;
		}

		InvokeRepeating("debugHealth", 2f, 0.3f);
	}
	public void debugHealth() {
		Debug.Log("Player health: " + playerHealth.CurrentHealth);
	}
	void Update () {

		
	}
}
