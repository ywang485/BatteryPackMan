using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour {

	private AttackingSubject attackingSubject;
	private string bulletPrefab = "Prefabs/EnemyBullet";
	private int cooldown = 50;
	private int cooldownCounter = 0;

	// Use this for initialization
	void Start () {
		attackingSubject = GetComponent<AttackingSubject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackingSubject.target != null) {
			if (cooldownCounter >= cooldown) {
				GameObject bullet = Instantiate (Resources.Load (bulletPrefab) as GameObject, transform.position, Quaternion.identity, GameObject.Find ("bullets").transform);
				bullet.GetComponent<EnemyBullet> ().direction = (attackingSubject.target.transform.position - transform.position);
				bullet.GetComponent<EnemyBullet> ().direction.Normalize ();
				cooldownCounter = 0;
			}
			cooldownCounter += 1;
		} else {
			// Find ane enemy
			GameObject[] candidates = GameObject.FindGameObjectsWithTag("PlayerUnit");
			if (candidates.Length > 0) {
				attackingSubject.target = candidates [0];
			} else {
				candidates = GameObject.FindGameObjectsWithTag("FlyingPlayerUnit");
				if (candidates.Length > 0) {
					attackingSubject.target = candidates [0];
				}
			}
		}
	}
}
