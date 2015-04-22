using UnityEngine;
using System.Collections;

public class TestObjectBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddTorque(new Vector3 (0.0f, 50.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
