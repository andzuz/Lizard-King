﻿using UnityEngine;
using System.Collections;

public class LizardCollisions : MonoBehaviour {

	private GameController gameController;
	private BonusController bonusController;
	public int scoreValue = 1;
	
	void Start() {
		InitGameController ();
		InitBonusController ();
	}

	void InitGameController() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void InitBonusController() {
		GameObject bonusControllerObject = GameObject.FindWithTag ("Bonus");
		
		if (bonusControllerObject != null) {
			bonusController = bonusControllerObject.GetComponent <BonusController>();
		}
	}

	void OnTriggerEnter(Collider other) {
		string tag = other.tag;
		
		if (tag.Equals ("Hazard")) {
			if(!bonusController.IsInvisibilityEnabled()) {
				gameController.GameOver();
			} else {
				Debug.Log ("MASZ NIEWIDZIALNOSC KURWO");
			}
		} else if (tag.Equals ("Reward")) {
			gameController.AddScore (scoreValue);
			DestroyObject(other.gameObject);
		}

	}

}
