﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene ("GamePlay");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
