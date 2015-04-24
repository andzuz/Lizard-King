using UnityEngine;
using System.Collections;

public class BonusController : MonoBehaviour {

	private BonusType bonusType;
	private GameController gameController;
	private const float INSECT_SWARM_DURATION = 5.0f;
	private const float INVISIBILITY_DURATION = 5.0f;
	private bool timing;
	private float countdown;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			EnableInsectSwarm ();
		} else if (Input.GetKeyDown (KeyCode.X)) {
			EnableInvisibility();
		}

		DecrementTimerIfRunning ();
	}

	void EnableInvisibility() {
		EnableBonus (BonusType.INVISIBILITY);
		StartTimer (INVISIBILITY_DURATION);
	}

	void EnableInsectSwarm() {
		EnableBonus(BonusType.INSECT_SWARM);
		StartTimer(INSECT_SWARM_DURATION);
	}

	void DecrementTimerIfRunning() {
		if(timing)
		{
			countdown -= Time.deltaTime;

			if(countdown <= 0)
			{
				CancelBonus();
				timing = false;
			}
		}
	}

	void StartTimer(float time)
	{
		timing = true;
		countdown = time;
	}

	public bool IsSwarmEnabled() {
		return bonusType == BonusType.INSECT_SWARM;
	}

	public bool IsInvisibilityEnabled() {
		return bonusType == BonusType.INVISIBILITY;
	}
	
	public void EnableBonus(BonusType type) {
		bonusType = type;
	}

	public void CancelBonus() {
		bonusType = BonusType.NONE;
	}

	public enum BonusType {
		NONE,
		INSECT_SWARM,
		INVISIBILITY
	}

}
