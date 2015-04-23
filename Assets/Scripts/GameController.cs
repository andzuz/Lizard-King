using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int zPos = 24;
	public int[] xPos = {-2, -1, 1, 2};
	public Transform hazardObject;
	public Transform rewardObject;

	void Start () {
		SpawnWaves ();
	}

	void SpawnWaves() {
		SpawnHazards ();
		SpawnRewards ();
	}

	void SpawnHazards () {
		int index = Random.Range (0, xPos.Length-1);
		Vector3 spawnPosition = new Vector3 (xPos [index], 0.0f, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazardObject, spawnPosition, spawnRotation);
	}

	void SpawnRewards () {
		int index = Random.Range (0, xPos.Length-1);
		Vector3 spawnPosition = new Vector3 (xPos [index], 0.0f, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazardObject, spawnPosition, spawnRotation);
	}

}
