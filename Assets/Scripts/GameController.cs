﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private float speed = 10.0f;
	private int score = 0;
	private bool isPaused = false;

	public GUIStyle scoreLabelStyle;
	public BonusController bonusController;
	public Spawner spawner;
	public int maxSpeed;

	public const int POINTS_TO_BONUS = 15;
	public const int BOOST_SPEED_AMOUNT = 1;

	void Start() {

	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.P)) {
			TogglePause ();
		} else if (Input.GetKeyDown (KeyCode.R) && isPaused) {
			RestartGame();
		}
	}

	void RestartGame() {
		Application.LoadLevel(Application.loadedLevel);
		UnpauseGame();
	}

	void BoostSpeed() {
		if (speed < maxSpeed) {
			speed += BOOST_SPEED_AMOUNT;
		}
		//StartCoroutine(BoostSpeedAsync());
	}

	IEnumerator BoostSpeedAsync() {
		for (float f = 0f; f < BOOST_SPEED_AMOUNT; f += 0.001f) {
			speed += 0.001f;
			Debug.Log(speed);
			yield return null;
		}
	}

	public float getSpeed() {
		return speed;
	}

	public void AddScore (int amount) {
		this.score += amount;

		if (this.score % POINTS_TO_BONUS == 0) {
			bonusController.EnableRandomBonus();
		} else if (this.score % 5 == 0) {
			BoostSpeed();
		}
	}

	public void PauseGame() {
		Time.timeScale = 0;
		isPaused = true;
	}

	public void UnpauseGame() {
		Time.timeScale = 1;
		isPaused = false;
	}

	public void TogglePause() {
		if (isPaused) {
			UnpauseGame ();
		} else {
			PauseGame ();
		}
	}

	public void GameOver () {
		PauseGame ();
	}

	void OnGUI() {
		if(isPaused) {
			int buttonWidth = 100;
			int buttonHeight = 50;
			
			float buttonX = (Screen.width - buttonWidth) / 2.0f;
			float buttonY = (Screen.height - buttonHeight) / 2.0f;
			
			if( GUI.Button( new Rect(buttonX, buttonY, buttonWidth, buttonHeight), "RESTART") ) {
				RestartGame();
			}
		}
		
		GUI.Label( new Rect(10, 10, 100, 20), score.ToString(), scoreLabelStyle );
	}

}
