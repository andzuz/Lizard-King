using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

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

	void Start () {
		BeginSpawning ();
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
				SpawnRandom();
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

	void OnTriggerExit(Collider other) {
		string tag = other.tag;
		Debug.Log (tag);

		if (tag.Equals("Hazard") || tag.Equals("Reward")) {
			Destroy (other.gameObject);
		}
	}

}
