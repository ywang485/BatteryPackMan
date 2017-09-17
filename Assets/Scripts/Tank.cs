using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

	private AttackingSubject attackingSubject;
	private PowerSubject powerSubject;
	private string bulletPrefab = "Prefabs/Bullet";
	private int basicCooldown = 5;
	private int coolDownMultiplier = 100;
	private int cooldownCounter = 0;
	private Animator animator;

	// Use this for initialization
	void Start () {
		attackingSubject = GetComponent<AttackingSubject> ();
		powerSubject = GetComponent<PowerSubject> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (attackingSubject.target != null) {
			if (powerSubject.power > 0f) {
				if (cooldownCounter >= basicCooldown + coolDownMultiplier * (1f - powerSubject.power)) {
					GameControl.getInstance ().playSFX (GameControl.bulletSFX);
					GameObject bullet = Instantiate (Resources.Load (bulletPrefab) as GameObject, transform.position, Quaternion.identity, GameObject.Find ("bullets").transform);
					bullet.GetComponent<Bullet> ().direction = (attackingSubject.target.transform.position - transform.position);
					bullet.GetComponent<Bullet> ().direction.Normalize ();
					cooldownCounter = 0;
				}
				cooldownCounter += 1;
			}
		} else {
			// Find ane enemy
			GameObject[] candidates = GameObject.FindGameObjectsWithTag("MinionMonster");
			if (candidates.Length > 0) {
				attackingSubject.target = candidates [0];
			} else {
				candidates = GameObject.FindGameObjectsWithTag ("RangedMonster");
				if (candidates.Length > 0) {
					attackingSubject.target = candidates [0];
				} else {
					candidates = GameObject.FindGameObjectsWithTag ("BossMonster");
					if (candidates.Length > 0) {
						attackingSubject.target = candidates [0];
					}
				}
			}
		}

		if (powerSubject.power <= 0) {
			animator.SetBool ("outOfPower", true);
		} else {
			animator.SetBool ("outOfPower", false);
		}

	}
}
