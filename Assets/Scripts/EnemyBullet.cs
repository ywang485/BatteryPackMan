using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	private AttackingSubject attackingSubject;
	private float speed = 5f;
	public Vector2 direction;
	public bool isArrow;

	// Use this for initialization
	void Start () {

		attackingSubject = GetComponent<AttackingSubject> ();
		//direction = new Vector2 (1f, 0f);

	}

	// Update is called once per frame
	void Update () {

		transform.Translate (direction * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PlayerUnit" || other.tag == "FlyingPlayerUnit") {
			attack (other.gameObject);
		}
	}

	private void attack(GameObject obj) {
		if (isArrow) {
			GameControl.getInstance ().playSFX (GameControl.arrowHitSFX);
		}
		obj.GetComponent<HpSubject> ().beAttacked (attackingSubject.strength);
		GameObject.Destroy (gameObject);
	}
}
