using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSubject : MonoBehaviour {

	public int hp = 100;
	public int maxHp = 100;
	public static readonly int healthRecoverCounterMax = 30;
	public int healthRecoverCounter = 0;
	public static readonly int healthRecoverRate = 1;
	private GameObject HPBarContent;

	// Use this for initialization
	void Start () {
		Transform HPBarContentTrans = transform.Find("HPBarContent");
		if (HPBarContentTrans != null) {
			HPBarContent = HPBarContentTrans.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.tag ==  "PlayerUnit" && healthRecoverCounter >= healthRecoverCounterMax && hp < maxHp) {
			hp += healthRecoverRate;
			healthRecoverCounter = 0;
			if (hp > maxHp) {
				hp = maxHp;
			}
		}
		healthRecoverCounter += 1;

		if (HPBarContent != null) {
			HPBarContent.transform.localScale = new Vector2 (1f * ((float)hp / (float)maxHp), 1f);
		}

	}

	public void beAttacked(int dmg) {
		hp -= dmg;
		Debug.Log (gameObject.name + " is being attacked (" + hp + "/100)");
		if (hp <= 0) {
			GameObject.Destroy (gameObject);
			Debug.Log (gameObject.name + " is dead.");
			if (gameObject.name == "player") {
				// Game Over
				Debug.Log("Game Over");
				GameControl.getInstance ().gameOver ();
			}
		}
	}
}
