using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusController : MonoBehaviour {

	public Text bonusText;

	private BonusType bonusType;
	private GameController gameController;
	private const float INSECT_SWARM_DURATION = 5.0f;
	private const float INVISIBILITY_DURATION = 5.0f;
	private const float BONUS_TEXT_DURATION = 3.0f;
	private const string SWARM_TEXT = "INSECT SWARM!";
	private const string INVISIBILITY_TEXT = "INVISIBILITY!";
	private bool timing;
	private float countdown;

	// Use this for initialization
	void Start () {
		bonusText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			EnableInsectSwarm ();
		} else if (Input.GetKeyDown (KeyCode.X)) {
			EnableInvisibility ();
		}

		DecrementTimerIfRunning ();
	}

	void EnableInvisibility() {
		EnableBonus (BonusType.INVISIBILITY);
		ShowBonusText (INVISIBILITY_TEXT);
		StartTimer (INVISIBILITY_DURATION);
	}

	void EnableInsectSwarm() {
		EnableBonus(BonusType.INSECT_SWARM);
		ShowBonusText (SWARM_TEXT);
		StartTimer(INSECT_SWARM_DURATION);
	}

	void ShowBonusText(string text) {
		bonusText.enabled = true;
		bonusText.text = text;
	}

	void DecrementTimerIfRunning() {
		if(timing)
		{
			countdown -= Time.deltaTime;;

			if(countdown <= BONUS_TEXT_DURATION) {
				bonusText.enabled = false;
			}

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

	public void EnableRandomBonus() {
		int choice = Random.Range (0, 2);

		if (choice == 1) {
			Debug.Log ("**** INSECT SWARM *****");
			EnableInsectSwarm();
		} else {
			Debug.Log ("**** INVISIBILITY *****");
			EnableInvisibility();
		}
	}

	public enum BonusType {
		NONE,
		INSECT_SWARM,
		INVISIBILITY
	}

}
