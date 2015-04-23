using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

	public float rotationFactor;
	//private bool isRotating = false;
	//private float angleSoFar = 0;
	//private Quaternion targetRotation = Quaternion.identity;

	public float MaxTiltAngle = 20.0f;
	public float tiltSpeed = 30.0f; // tilting speed in degrees/second

	Vector3 curRot;
	float maxX;
	float maxZ;
	float minX;
	float minZ;


	// Use this for initialization
	void Start () {
		kaka();
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown(KeyCode.A)) {
			//RotateTree ();
			demona();
			//transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationFactor * Time.deltaTime);
		//}
	}

	public void kaka() {
		// Get initial rotation
		curRot = this.transform.eulerAngles;
		// calculate limit angles:
		maxX = curRot.x + MaxTiltAngle;
		maxZ = curRot.z + MaxTiltAngle;
		minX = curRot.x - MaxTiltAngle;
		minZ = curRot.z - MaxTiltAngle;
	}

	public void demona() {
		// "rotate" the angles mathematically:
		curRot.x += Input.GetAxis("Vertical") * Time.deltaTime * tiltSpeed;
		curRot.z += Input.GetAxis("Horizontal") * Time.deltaTime * tiltSpeed;                
		// Restrict rotation along x and z axes to the limit angles:
		curRot.x = Mathf.Clamp(curRot.x, minX, maxX);
		curRot.z = Mathf.Clamp(curRot.z, minZ, maxZ);
		
		// Set the object rotation
		this.transform.eulerAngles = curRot;
	}

	private void RotateTreeByGivenAngle() {
		Vector3 oldPoint = new Vector3(0.0f,0.0f,0.0f);
		Vector3 newPoint = new Vector3 (20.0f, 0.0f, 0.0f);

		Vector3 x = Vector3.Cross (oldPoint.normalized, newPoint.normalized);
		float theta = Mathf.Asin (x.magnitude);
		Vector3 w = x.normalized * theta / Time.fixedDeltaTime;

		Quaternion q = transform.rotation * GetComponent<Rigidbody>().inertiaTensorRotation;
		Vector3 T = q * Vector3.Scale (GetComponent<Rigidbody>().inertiaTensor, (Quaternion.Inverse (q) * w));

		GetComponent<Rigidbody>().AddTorque (T, ForceMode.Impulse);

	}
	
	private void RotateTree() {
		/*float horiz = Input.GetAxis ("Horizontal");
		int direction;

		if (horiz > 0) {
			direction = 1;
		} else if (horiz < 0) {
			direction = -1;
		} else {
			direction = 0;
		}

		transform.Rotate (new Vector3(0.0f, 1.0f, 0.0f), 20.0f * Time.deltaTime);
		angleSoFar += 20.0f * Time.deltaTime;

		if (angleSoFar >= rotationFactor) {
			isRotating = true;
		}*/

		//Transform afterRotation = transform;
		//afterRotation.Rotate (new Vector3(0.0f, 1.0f, 0.0f), direction * rotationFactor);
		//transform.rotation = Quaternion.Slerp(transform.rotation, afterRotation.rotation, Time.deltaTime * rotationFactor);
		//Transform tmp = transform;
		//tmp.rotation = new Quaternion(transform.x, transform.y, transfo 
	}

}
