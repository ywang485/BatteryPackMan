using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraduallyEnter : MonoBehaviour {

	private int counter = 0;
	private int counterMax = 100;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		counter = 0;
		Color currColor = GetComponent<Text> ().color;
		GetComponent<Text> ().color = new Color (currColor.r, currColor.g, currColor.b, 0f);
	}

	// Update is called once per frame
	void Update () {
		if (counter < counterMax) {
			counter += 1;
		}
		Color currColor = GetComponent<Text> ().color;
		GetComponent<Text> ().color = new Color (currColor.r, currColor.g, currColor.b, (float)counter / (float)counterMax);
	}
}
