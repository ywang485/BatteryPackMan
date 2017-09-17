using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	private AudioSource audioSrc;

	public static readonly string bulletSFX = "SFX/Bullet";
	public static readonly string chargeSFX = "SFX/Charge";
	public static readonly string robotHitSFX = "SFX/RobotHit";
	public static readonly string monsterHitSFX = "SFX/MonsterHit";
	public static readonly string arrowHitSFX = "SFX/ArrowHit";

	public GameObject gameOverPanel;
	public Text scoreText;
	public GameObject youWinPanel;
	public Text inGameScoreText;
	public bool won = false;

	private float gameStartTime;

	static public GameControl getInstance() {
		return GameObject.Find ("Main Camera").GetComponent<GameControl>(); 
	}

	public void playSFX(string SFX) {
		audioSrc.PlayOneShot (Resources.Load(SFX, typeof(AudioClip)) as AudioClip);
	}

	public void playerWins() {
		Time.timeScale = 0f;
		youWinPanel.SetActive (true);
	}

	public void gameOver() {
		Time.timeScale = 0f;
		gameOverPanel.SetActive (true);
		scoreText.text = "Score: " + (int)((Time.time - gameStartTime)) + "\n (Click to start new game)";
	}

	public void continuePlay() {
		Debug.Log ("ContinuePlay Enteredß");
		Time.timeScale = 1f;
		won = true;
		youWinPanel.SetActive (false);
	}

	public void startNewGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("StartNewGame");
	}

	// Use this for initialization
	void Start () {
		audioSrc = GetComponent<AudioSource> ();
		gameStartTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		int score = (int)((Time.time - gameStartTime));
		if (inGameScoreText != null) {
			inGameScoreText.text = "Score: " + score;
			if (score >= 300 && !won) {
				playerWins ();
			}
		}
	}
}
