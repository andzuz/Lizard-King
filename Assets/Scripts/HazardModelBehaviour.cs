using UnityEngine;
using System.Collections;

public class HazardModelBehaviour : MonoBehaviour {

	private const int maxAngle = 360;

	// Use this for initialization
	void Start () {
		int randDeg = Random.Range(0, maxAngle);
		transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), (float) randDeg); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
