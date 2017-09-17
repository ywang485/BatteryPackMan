using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	private float speed = 1f;
	private float bouncingDistance = 1f;
	private AttackingSubject attackingSubject;
	private string monsterAttackAnim = "Prefabs/MonsterAttackAnim";

	// Use this for initialization
	void Start () {
		attackingSubject = GetComponent<AttackingSubject> ();
	}

	// Update is called once per frame
	void Update () {

		if (attackingSubject.target == null) {
			// Find a target
			GameObject[] candidates = GameObject.FindGameObjectsWithTag("PlayerUnit");
			if (candidates.Length > 0) {
				attackingSubject.target = candidates [0];
			} else {
				transform.Translate (new Vector3 (-1 * speed * Time.deltaTime, 0f));
			}
		} else {
			transform.position = Vector2.MoveTowards (transform.position, attackingSubject.target.transform.position, 1.5f * speed * Time.deltaTime);
		}

		if (transform.position.x < Player.boundaryLeft - 1f) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PlayerUnit") {
			attack (other.gameObject);
		}
	}

	private void attack(GameObject obj) {
		GameControl.getInstance ().playSFX (GameControl.monsterHitSFX);
		Instantiate (Resources.Load(monsterAttackAnim, typeof(GameObject)) as GameObject, obj.transform.position, Quaternion.identity);
		obj.GetComponent<HpSubject> ().beAttacked (attackingSubject.strength);
		Vector2 drct = transform.position - obj.transform.position;
		drct.Normalize ();
		Vector2 currPos = transform.position;
		transform.position = currPos + drct * bouncingDistance;
	}
}
