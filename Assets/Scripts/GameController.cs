using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int speed = 10;
	private int score = 0;
	private bool isPaused = false;

	public BonusController bonusController;
	public Spawner spawner;
	public float waveWait;
	public float spawnWait;
	public float startWait;
	public int hazardCount = 5;
	public int maxSpeed;

	public const int POINTS_TO_BONUS = 20;
	public const int BOOST_SPEED_AMOUNT = 1;


	void Start () {
		//InitBonusController ();
		BeginSpawning ();
	}

	/*void InitBonusController() {
		GameObject bonusControllerObject = GameObject.FindWithTag ("Bonus");
		
		if (bonusControllerObject != null) {
			bonusController = bonusControllerObject.GetComponent <BonusController>();
		}
	}*/

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
	}

	void BeginSpawning() {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if(bonusController.IsSwarmEnabled()) {
					spawner.SpawnReward();
				} else {
					spawner.SpawnRandom();
				}

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public int getSpeed() {
		return speed;
	}

	public void AddScore (int amount) {
		this.score += amount;

		if (this.score % POINTS_TO_BONUS == 0) {
			bonusController.EnableRandomBonus();
		} else if (this.score % 5 == 0) {
			BoostSpeed();
		}

		Debug.Log ("Score: " + score);
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

}
