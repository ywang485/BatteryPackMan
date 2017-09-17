using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndGoNext : MonoBehaviour {

	public GameObject next;
	public float delay = 5f;


	// Use this for initialization
	void Start () {
		Destroy (gameObject, delay);
	}

	void OnDestroy() {
		if (next != null) {
			next.SetActive (true);
		}
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
