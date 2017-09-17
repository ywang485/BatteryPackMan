using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private AttackingSubject attackingSubject;
	private float speed = 7f;
	public Vector2 direction;


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
		if (other.tag == "BossMonster" || other.tag == "MinionMonster" || other.tag == "FlyingMonster" || other.tag == "RangedMonster") {
			attack (other.gameObject);
		}
	}

	private void attack(GameObject obj) {
		obj.GetComponent<HpSubject> ().beAttacked (attackingSubject.strength);
		GameObject.Destroy (gameObject);
	}

}
