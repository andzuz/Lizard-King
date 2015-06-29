using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButtonBehaviour : MonoBehaviour {

	public Button startButton;

	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(delegate {
			Application.LoadLevel("GameScene");
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
