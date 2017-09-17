using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour {

	private HashSet<string> tags2detectSet;
	public string[] tags2detect;

	void Start() {
		tags2detectSet = new HashSet<string> ();
		foreach (string tag in tags2detect) {
			tags2detectSet.Add (tag);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (tags2detectSet.Contains(other.tag)) {
			GetComponentInParent<AttackingSubject>().target = other.gameObject;
		}
	}
}
