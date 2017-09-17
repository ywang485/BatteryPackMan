using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPanel : MonoBehaviour {

	public GameObject next;

	public void goNext() {
		if (next != null) {
			next.SetActive (true);
		}
		gameObject.SetActive(false);
	}
}
