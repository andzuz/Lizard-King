using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public BonusController bonusController;
	public int zPos = 24;
	public int[] xPos = {-2, -1, 1, 2};
	public int[] xLeafPos = {-2, 2};
	public Transform hazardObject;
	public Transform rewardObject;
	public Transform leafLeftObject;
	public Transform leafRightObject;
	public float waveWait;
	public float spawnWait;
	public float startWait;
	public float leavesWait;
	public int hazardCount;

	public const int WAVE_HAZARD = 0;
	public const int WAVE_REWARD = 1;

	void Start () {
		BeginSpawning ();
	}

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

	public void SpawnLeaf () {
		int index = Random.Range (0, xLeafPos.Length);
		int rotation = Random.Range (-20, 20);
		int position = Random.Range (-1, 1);
		Vector3 spawnPosition = new Vector3 (xLeafPos [index] + position, 8.0f + position, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		leafLeftObject.GetChild (0).Rotate(new Vector3(0, rotation, 0));

		if (index == 0) {
			Instantiate (leafLeftObject, spawnPosition, spawnRotation);
		} else {
			Instantiate (leafRightObject, spawnPosition, spawnRotation);
		}
	}

	public void SpawnRandom() {
		int choice = Random.Range (0, 2);
		
		if (choice == WAVE_HAZARD) {
			SpawnHazard();
		} else if (choice == WAVE_REWARD) {
			SpawnReward();
		}
	}

	void BeginSpawning() {
		StartCoroutine (SpawnWaves ());
		StartCoroutine (SpawnLeaves ());
	}
	
	IEnumerator SpawnLeaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			SpawnLeaf();
			yield return new WaitForSeconds (leavesWait);
		}
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


}
