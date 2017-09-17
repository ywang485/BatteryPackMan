using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingRobot : MonoBehaviour {

	private AttackingSubject attackingSubject;
	private PowerSubject powerSubject;
	private float speed = 1.5f;
	private float bouncingDistance = 0.5f;
	private float bouncingDistanceMultiplier = 2f;
	private Vector2 standbyPosition = new Vector2 (-3.54f, -0.33f);
	private Animator animator;
	private string robotAttackAnim = "Prefabs/RobotAttackAnim";

	// Use this for initialization
	void Start () {
		attackingSubject = GetComponent<AttackingSubject> ();
		powerSubject = GetComponent<PowerSubject> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackingSubject.target != null) {
			transform.position = Vector2.MoveTowards (transform.position, attackingSubject.target.transform.position, 1.5f * speed * powerSubject.power * Time.deltaTime);
		} else {
			// Find ane enemy
			GameObject[] candidates = GameObject.FindGameObjectsWithTag("BossMonster");
			if (candidates.Length > 0) {
				attackingSubject.target = candidates [0];
			} else {
				candidates = GameObject.FindGameObjectsWithTag ("RangedMonster");
				if (candidates.Length > 0) {
					attackingSubject.target = candidates [0];
				} else {
					transform.position = Vector2.MoveTowards (transform.position, standbyPosition, 1.0f * speed * powerSubject.power * Time.deltaTime);
				}
			}
		}

		Vector2 currPos = transform.position;
		transform.position = new Vector2 (Mathf.Max (Mathf.Min (Player.boundaryRight, currPos.x), Player.boundaryLeft), Mathf.Max (Mathf.Min (currPos.y, Player.boundaryTop), Player.boundaryBottom));

		if (powerSubject.power <= 0) {
			animator.SetBool ("outOfPower", true);
		} else {
			animator.SetBool ("outOfPower", false);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "MinionMonster" || other.tag == "BossMonster" || other.tag == "RangedMonster") {
			attack (other.gameObject);
		}
	}

	private void attack(GameObject obj) {
		GameControl.getInstance ().playSFX (GameControl.robotHitSFX);
		Instantiate (Resources.Load(robotAttackAnim, typeof(GameObject)) as GameObject, obj.transform.position, Quaternion.identity);
		obj.GetComponent<HpSubject> ().beAttacked ((int) (attackingSubject.strength * powerSubject.power));
		Vector2 drct = transform.position - obj.transform.position;
		drct.Normalize ();
		Vector2 currPos = transform.position;
		transform.position = currPos + drct * (bouncingDistance * powerSubject.power * bouncingDistanceMultiplier);
	}

}
