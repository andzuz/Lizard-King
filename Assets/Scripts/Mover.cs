using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private float speed;
	private GameController gameController;
	private float lastKnownSpeed;

	void Start () {
		InitGameController ();
		lastKnownSpeed = speed = gameController.getSpeed ();
		GetComponent<Rigidbody>().velocity = transform.forward * -speed;
	}

	void Update() {
		speed = gameController.getSpeed ();

		if (lastKnownSpeed != speed) {
			Debug.Log ("NOWY SPEED " + speed);
			GetComponent<Rigidbody>().velocity = transform.forward * -speed;
			lastKnownSpeed = speed;
		}
	}

	void InitGameController() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

}
