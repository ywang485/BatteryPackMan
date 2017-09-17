using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCGControl : MonoBehaviour {

	private bool batteryDead = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		foreach (GameObject unit in playerUnits) {
			if (batteryDead) {
				unit.GetComponent<PowerSubject> ().power = 0f;
			} else {
				unit.GetComponent<PowerSubject> ().power = 1f;
			}
		}
		playerUnits = GameObject.FindGameObjectsWithTag ("FlyingPlayerUnit");
		foreach (GameObject unit in playerUnits) {
			if (batteryDead) {
				unit.GetComponent<PowerSubject> ().power = 0f;
			} else {
				unit.GetComponent<PowerSubject> ().power = 1f;
			}
		}
	}

	public void setBatteryDead() {
		batteryDead = true;
	}

	public void spawnEnemy() {
		MonsterSpawner ms = GameObject.Find ("MonsterSpawner").GetComponent<MonsterSpawner> ();
		ms.spawnBossMonster ();
		ms.spawnFlyingMonster ();
		ms.spawnMinionMonster ();
		ms.spawnMinionMonster ();
		ms.spawnMinionMonster ();
		ms.spawnMinionMonster ();
		ms.spawnRangedMonster ();
	}

	public void startGame() {
		SceneManager.LoadScene ("Intro");
	}

}
