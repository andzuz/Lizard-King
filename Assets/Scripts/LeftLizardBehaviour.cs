using UnityEngine;
using System.Collections;

public class LeftLizardBehaviour : MonoBehaviour {
	
	public float timeTakenDuringLerp;
	public float distanceToMove;
	public LizardType lizardType;
	public GameObject modelObject;

	private int direction;
	private bool _isLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private float _timeStartedLerping;

	void StartLerping() {
		_isLerping = true;
		_timeStartedLerping = Time.time;

		_startPosition = transform.position;
		_endPosition = transform.position + Vector3.right*direction*distanceToMove;
	}

	void Start() {
		if (lizardType == LizardType.LEFT) {
			direction = 1;
		} else {
			direction = -1;
		}
	}

	void Update() {
		switch (lizardType) {
		case LizardType.LEFT:
			if(Input.GetKeyDown(KeyCode.A)) {
				ToggleDirection();
			}
			break;

		case LizardType.RIGHT:
			if(Input.GetKeyDown(KeyCode.D)) {
				ToggleDirection();
			}
			break;
		}

		DetectFingerInput();
	}

	void DetectFingerInput() {
		int screenWidth = Screen.width;

		for(int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);

			if(touch.phase == TouchPhase.Began) {
				switch (lizardType) {
				case LizardType.LEFT:
					if(touch.position.x < screenWidth/2) {
						ToggleDirection();
					}
					break;
					
				case LizardType.RIGHT:
					if(touch.position.x > screenWidth/2) {
						ToggleDirection();
					}
					break;
				}
			}
		}
	}

	private void ToggleDirection() {
		direction = -direction;
		StartLerping();
	}

	//We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
	void FixedUpdate() {
		if(_isLerping)
		{
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;
		
			transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);

			if(percentageComplete >= 1.0f) {
				_isLerping = false;
			}
		}
	}

	public enum LizardType {
		LEFT,
		RIGHT
	}

}
