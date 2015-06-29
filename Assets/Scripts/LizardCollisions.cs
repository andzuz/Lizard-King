using UnityEngine;
using System.Collections;

public class LizardCollisions : MonoBehaviour {

	private AudioSource[] audios;
	private GameController gameController;
	private BonusController bonusController;
	public int scoreValue = 1;

	private const int REWARD_AUDIO = 0;
	private const int FAIL_AUDIO = 1;

	void Start() {
		InitGameController ();
		InitBonusController ();
	}

	void InitGameController() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		audios = GetComponents<AudioSource>();

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
				audios[FAIL_AUDIO].Play();
			} else {
			}
		} else if (tag.Equals ("Reward")) {
			gameController.AddScore (scoreValue);
			DestroyObject(other.gameObject);
			audios[REWARD_AUDIO].Play();
		}

	}

}
