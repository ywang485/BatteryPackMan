using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSubject : MonoBehaviour {

	public float power = 1f;
	private GameObject powerBarContent;
	public static float powerMax = 1f;

	private float powerDecayRate = 0.001f;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		powerBarContent = transform.Find ("PowerBarContent").gameObject;
		sr = powerBarContent.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		power -= powerDecayRate;
		if (power < 0) {
			power = 0;
		}

		powerBarContent.transform.localScale = new Vector2 (1f * power, 1f);
		if (power < 0.3f) {
			sr.color = Color.red;
		} else if (power < 0.6f) {
			sr.color = Color.yellow;
		} else {
			sr.color = Color.white;
		}
	}
}
