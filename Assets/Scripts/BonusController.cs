using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusController : MonoBehaviour {

	public Text bonusLabel;

	private AudioSource bonusAudio;
	private BonusType bonusType;
	private GameController gameController;
	private const float INSECT_SWARM_DURATION = 5.0f;
	private const float INVISIBILITY_DURATION = 5.0f;
	private const float BONUS_TEXT_DURATION = 3.0f;
	private const string SWARM_TEXT = "INSECT SWARM!";
	private const string INVISIBILITY_TEXT = "INVISIBILITY!";
	private bool timing;
	private float countdown;
	private string bonusTextText;
	private bool bonusTextEnabled;

	// Use this for initialization
	void Start () {
		bonusTextEnabled = false;
		bonusAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			EnableInsectSwarm ();
		} else if (Input.GetKeyDown (KeyCode.X)) {
			EnableInvisibility ();
		}

		DecrementTimerIfRunning ();
		ShowBonusLabelIfNeeded ();
	}

	void ShowBonusLabelIfNeeded () {
		if (bonusTextEnabled) {
			if (!bonusLabel.enabled) {
				bonusLabel.enabled = true;
			}
			bonusLabel.text = bonusTextText;
		}
		else {
			bonusLabel.enabled = false;
		}
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
		bonusTextEnabled = true;
		bonusTextText = text;
	}

	void DecrementTimerIfRunning() {
		if(timing)
		{
			countdown -= Time.deltaTime;;

			if(countdown <= BONUS_TEXT_DURATION) {
				bonusTextEnabled = false;
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
		bonusAudio.Play();
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
