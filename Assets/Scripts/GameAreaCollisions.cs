using UnityEngine;
using System.Collections;

public class GameAreaCollisions : MonoBehaviour {
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void OnTriggerExit(Collider other) {
		string tag = other.tag;
		
		if (tag.Equals("Hazard") || tag.Equals("Reward") || tag.Equals("Leaf")) {
			Debug.Log(other.gameObject);
			Destroy (other.gameObject);

			if (tag.Equals("Reward")) {
				gameController.GameOver();
			}
		} 
	}

}
