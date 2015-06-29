using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private float speed = 10.0f;
	private int score = 0;
	private bool isPaused = false;

	public GameObject panel;
	public Text highScoreText;
	public Button retryButton;
	public Button menuButton;
	public Button pauseButton;
	public Text scoreLabel;
	public BonusController bonusController;
	public Spawner spawner;
	public int maxSpeed;

	public const int POINTS_TO_BONUS = 15;
	public const int BOOST_SPEED_AMOUNT = 1;
	private const string HIGH_SCORE_KEY = "HSK";

	void Start() {
		retryButton.onClick.AddListener(delegate {
			RestartGame();
		});
		menuButton.onClick.AddListener(delegate {
			UnpauseGame();
			Application.LoadLevel("Menu");
		});
		pauseButton.onClick.AddListener(delegate {
			TogglePause();
		});

		panel.SetActive(false);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.P)) {
			TogglePause ();
		} else if (Input.GetKeyDown (KeyCode.R) && isPaused) {
			RestartGame();
		}

		scoreLabel.text = score.ToString();
	}

	void RestartGame() {
		Application.LoadLevel(Application.loadedLevel);
		UnpauseGame();
	}

	void BoostSpeed() {
		if (speed < maxSpeed) {
			speed += BOOST_SPEED_AMOUNT;
		}
		//StartCoroutine(BoostSpeedAsync());
	}

	IEnumerator BoostSpeedAsync() {
		for (float f = 0f; f < BOOST_SPEED_AMOUNT; f += 0.001f) {
			speed += 0.001f;
			Debug.Log(speed);
			yield return null;
		}
	}

	public float getSpeed() {
		return speed;
	}

	public void AddScore (int amount) {
		this.score += amount;

		if (this.score % POINTS_TO_BONUS == 0) {
			bonusController.EnableRandomBonus();
		} else if (this.score % 5 == 0) {
			BoostSpeed();
		}
	}

	public void PauseGame() {
		Time.timeScale = 0;
		isPaused = true;
	}

	public void UnpauseGame() {
		Time.timeScale = 1;
		isPaused = false;
	}

	public void TogglePause() {
		if (isPaused) {
			UnpauseGame ();
		} else {
			PauseGame ();
		}
	}

	void WriteScore ()
	{
		PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
	}

	void WriteScoreIfHigh ()
	{
		int savedScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
		if(savedScore < score) {
			WriteScore();
		}
	}

	void UpdateHighScore ()
	{
		int savedScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
		highScoreText.text = "HIGH SCORE IS " + savedScore;
	}

	public void GameOver () {
		WriteScoreIfHigh();
		PauseGame ();
		UpdateHighScore();
		panel.SetActive(true);
	}

}
