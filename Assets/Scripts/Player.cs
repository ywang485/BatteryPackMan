using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private float speed = 1.5f;
	public static readonly float boundaryTop = 0.4f;
	public static readonly float boundaryLeft = -6f;
	public static readonly float boundaryBottom = -4.0f;
	public static readonly float boundaryRight = 6f;
	private float power = 1f;
	private float powerMax = 2f;
	private float powerRecoverRate = 0.003f;
	private float chargingSpeed = 0.03f;
	private Animator animator;
	private GameControl gameControl;
	private AudioSource audioSrc;

	// Power Indicator
	public Image powerIndicator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		gameControl = GameControl.getInstance ();
		audioSrc = GetComponent<AudioSource> ();
	}
		
	void playChargingSFX() {
		if (!audioSrc.isPlaying) {
			audioSrc.PlayOneShot (Resources.Load(GameControl.chargeSFX, typeof(AudioClip)) as AudioClip);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "PlayerUnit" && Input.GetMouseButton(1)) {
			PowerSubject powerSubj = other.gameObject.GetComponent<PowerSubject> ();
			if (powerSubj != null && powerSubj.power < PowerSubject.powerMax && power > chargingSpeed) {
				playChargingSFX ();
				powerSubj.power += chargingSpeed;
				power -= chargingSpeed;
				if (power < 0) {
					power = 0;
				}
				if (powerSubj.power > PowerSubject.powerMax) {
					powerSubj.power = PowerSubject.powerMax;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		float movex = Input.GetAxis ("Horizontal");
		float movey = Input.GetAxis ("Vertical");

		if (movex > 0) {
			movex = 1;
		}
		if (movey > 0) {
			movey = 1;
		}

		if (Input.GetKey (KeyCode.Space)) {
			animator.SetBool ("isWirelessCharging", true);
			GameObject planeFighter = GameObject.Find ("PlaneFighter");
			PowerSubject planePowerSubj = planeFighter.GetComponent<PowerSubject> ();
			if (planePowerSubj.power < PowerSubject.powerMax && power > chargingSpeed) {
				playChargingSFX ();
				planePowerSubj.power += chargingSpeed;
				power -= chargingSpeed;
				if (power < 0) {
					power = 0;
				}
				if (planePowerSubj.power > PowerSubject.powerMax) {
					planePowerSubj.power = PowerSubject.powerMax;
				}
			}
		} else {
			animator.SetBool ("isWirelessCharging", false);
		}

		//transform.Translate (new Vector2(movex * speed, movey * speed));
		GetComponent<Rigidbody2D>().velocity = new Vector2(movex*speed, movey*speed);
		Vector2 currPos = transform.position;
		transform.position = new Vector2 (Mathf.Max (Mathf.Min (boundaryRight, currPos.x), boundaryLeft), Mathf.Max (Mathf.Min (currPos.y, boundaryTop), boundaryBottom));

		power += powerRecoverRate;
		if (power > powerMax) {
			power = powerMax;
		}

		powerIndicator.gameObject.GetComponent<RectTransform> ().localScale = new Vector2 (power/powerMax, 1f);

	}

}
