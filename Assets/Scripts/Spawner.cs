using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public int zPos = 24;
	public int[] xPos = {-2, -1, 1, 2};
	public Transform hazardObject;
	public Transform rewardObject;

	public const int WAVE_HAZARD = 0;
	public const int WAVE_REWARD = 1;

	public void SpawnHazard () {
		int index = Random.Range (0, xPos.Length);
		Vector3 spawnPosition = new Vector3 (xPos [index], 0.0f, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazardObject, spawnPosition, spawnRotation);
	}
	
	public void SpawnReward () {
		int index = Random.Range (0, xPos.Length);
		Vector3 spawnPosition = new Vector3 (xPos [index], 0.0f, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (rewardObject, spawnPosition, spawnRotation);
	}

	public void SpawnRandom() {
		int choice = Random.Range (0, 2);
		
		if (choice == WAVE_HAZARD) {
			SpawnHazard();
		} else if (choice == WAVE_REWARD) {
			SpawnReward();
		}
	}

}
