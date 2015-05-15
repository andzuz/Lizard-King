using UnityEngine;
using System.Collections;

public class TreeModelBehaviour : MonoBehaviour {	

	public GameController gameController;
	public float scaleFactor;

	private Renderer renderer;
	private float speed;
	
	void Start () {
		this.renderer = GetComponent<Renderer>();
		initGameController();
	}

	void initGameController ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void Update () {
		speed = gameController.getSpeed();
		float offset = Time.time * speed / scaleFactor;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
