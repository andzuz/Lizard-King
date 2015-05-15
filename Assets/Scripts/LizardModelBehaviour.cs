using UnityEngine;
using System.Collections;

public class LizardModelBehaviour : MonoBehaviour {

	public BonusController bonusController;

	private Renderer renderer;
	float r;
	float g;
	float b;

	void Start() {
		this.renderer = GetComponent<Renderer>();
		r = this.renderer.material.color.r;
		g = this.renderer.material.color.g;
		b = this.renderer.material.color.b;
	}

	void Update() {
		if(bonusController.IsInvisibilityEnabled()) {
			MakeInvisible();
		} else {
			MakeVisible();
		}
	}

	public void MakeInvisible() {
		this.renderer.material.color = new Color(r, g, b, 0.3f);
	}

	public void MakeVisible() {
		this.renderer.material.color = new Color(r, g, b, 1.0f);
	}

}
