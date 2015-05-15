using UnityEngine;
using System.Collections;

public class TreeModelBehaviour : MonoBehaviour {	
	
	public Rigidbody hazardBody;
	public float scaleFactor;

	private Renderer renderer;
	private float speed;
	
	void Start () {
		this.renderer = GetComponent<Renderer>();
	}

	void Update () {
		speed = -hazardBody.velocity.z;
		float offset = Time.time * speed / scaleFactor;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
