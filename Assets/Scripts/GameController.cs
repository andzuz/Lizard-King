using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int speed = 10;
	private int score = 0;
	private BonusController bonusController;
	public float waveWait;
	public float spawnWait;
	public float startWait;
	public int hazardCount = 5;
	public int zPos = 24;
	public int[] xPos = {-2, -1, 1, 2};
	public Transform hazardObject;
	public Transform rewardObject;
	public const int WAVE_HAZARD = 0;
	public const int WAVE_REWARD = 1;
	public const int POINTS_TO_BONUS = 20;
	public const int BOOST_SPEED_AMOUNT = 1;
	public int maxSpeed;

	void Start () {
		InitBonusController ();
		Debug.Log (bonusController);
		BeginSpawning ();
	}

	void InitBonusController() {
		GameObject bonusControllerObject = GameObject.FindWithTag ("Bonus");
		
		if (bonusControllerObject != null) {
			bonusController = bonusControllerObject.GetComponent <BonusController>();
		}
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
					SpawnReward();
				} else {
					SpawnRandom();
				}

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void SpawnRandom() {
		int choice = Random.Range (0, 2);

		if (choice == WAVE_HAZARD) {
			SpawnHazard();
		} else if (choice == WAVE_REWARD) {
			SpawnReward();
		}
	}

	void SpawnHazard () {
		int index = Random.Range (0, xPos.Length);
		Vector3 spawnPosition = new Vector3 (xPos [index], 0.0f, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazardObject, spawnPosition, spawnRotation);
	}

	void SpawnReward () {
		int index = Random.Range (0, xPos.Length);
		Vector3 spawnPosition = new Vector3 (xPos [index], 0.0f, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (rewardObject, spawnPosition, spawnRotation);
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

	public void GameOver () {

	}

}
