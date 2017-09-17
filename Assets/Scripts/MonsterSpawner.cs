using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

	private string bossMonsterPrefab = "Prefabs/BossMonster";
	private string minionMonsterPrefab = "Prefabs/MinionMonster";
	private string flyingMonsterPrefab = "Prefabs/FlyingMonster";
	private string rangedMonsterPrefab = "Prefabs/RangedMonster";

	private int level = 1;
	private int counter = 1;
	private int minionMonsterCounterMax = 300;
	private int bossMonsterCounterMax = 1800;
	private int flyingMonsterCounterMax = 1000;
	private int rangedMonsterCounterMax = 600;
	private int counterMax = 3000;
	private int counterRest = 2000;

	// Use this for initialization
	void Start () {
		
	}

	public void spawnBossMonster() {
		Vector2 selfPos = transform.position;
		Instantiate (Resources.Load (bossMonsterPrefab) as GameObject, selfPos + new Vector2 (Random.Range (-3f, -1f), Random.Range (-2f, 2f)), Quaternion.identity, GameObject.Find ("monsters").transform);
	}

	public void spawnMinionMonster() {
		Vector2 selfPos = transform.position;
		Instantiate (Resources.Load (minionMonsterPrefab) as GameObject, selfPos + new Vector2 (Random.Range (-2f, 2f), Random.Range (-2f, 2f)), Quaternion.identity, GameObject.Find ("monsters").transform);
	}

	public void spawnFlyingMonster() {
		Vector2 selfPos = transform.position;
		Instantiate (Resources.Load (flyingMonsterPrefab) as GameObject, selfPos + new Vector2 (-3f, 5f), Quaternion.identity, GameObject.Find ("monsters").transform);
	}

	public void spawnRangedMonster() {
		Vector2 selfPos = transform.position;
		Instantiate (Resources.Load (rangedMonsterPrefab) as GameObject, selfPos + new Vector2 (Random.Range (-3f, -1f), Random.Range (-2f, 2f)), Quaternion.identity, GameObject.Find ("monsters").transform);
	}
	
	// Update is called once per frame
	void Update () {
		counter += 1;
		if (counter >= counterMax) {
			counter = 1;
			level += 1;
		}
		if (counter % 100 == 0) {
			spawnMinionMonster ();
		}
		if (counter < counterRest) {
			if (counter % bossMonsterCounterMax == 0) {
				int num2Spawn = Random.Range (1, level/2);
				for (int i = 0; i < num2Spawn; i += 1) {
					spawnBossMonster ();
				}
			}
			if (counter % minionMonsterCounterMax == 0) {
				int num2Spawn = 3 + Random.Range (-level, level*2);
				for (int i = 0; i < num2Spawn; i += 1) {
					spawnMinionMonster ();
				}
			}
			if (counter % flyingMonsterCounterMax == 0) {
				int num2Spawn = Random.Range (1, level);
				for (int i = 0; i < num2Spawn; i += 1) {
					spawnFlyingMonster ();
				}
			}
			if (counter % rangedMonsterCounterMax == 0) {
				int num2Spawn = Random.Range (1, level);
				for (int i = 0; i < num2Spawn; i += 1) {
					spawnRangedMonster ();
				}
			}
		}
	}
}
