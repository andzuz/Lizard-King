using UnityEngine;
using System.Collections;

public class TextureMovement : MonoBehaviour {	
	
	public Rigidbody hazardBody;
	public float scaleFactor;
	public string texture;

	private Renderer renderer;
	private float speed;
	
	void Start () {
		this.renderer = GetComponent<Renderer>();
	}

	void Update () {
		speed = -hazardBody.velocity.z;
		float offset = Time.time * speed / scaleFactor;
		renderer.material.SetTextureOffset(texture, new Vector2(0, offset));
	}
}
