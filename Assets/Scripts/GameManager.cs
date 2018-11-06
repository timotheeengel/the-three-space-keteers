using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private float _gameTime = 90;
	private float _countDown;
	
	private Text _callToAction_Start;
	private Text _countDownDisplay;	
	private bool _hasGameStarted = false;
	private bool _hasGameEnded = false;

	private string _countDownText = " seconds left";
	
	private AsteroidSpawner _asteroidSpawner;
	private ScoreManager _scoreManager;
	
	// Use this for initialization
	void Start ()
	{
		_countDown = _gameTime;
		Time.timeScale = 0f;
		_callToAction_Start = GameObject.Find("SpaceToStart").GetComponent<Text>();
		_countDownDisplay = GameObject.Find("CountDown").GetComponent<Text>();

		_countDownDisplay.text = _gameTime + _countDownText;
		
		_asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
		_scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_hasGameStarted)
		{
			StartGame();
		}
		else if (!_hasGameEnded)
		{
			EndGame();
		}
		else if (_hasGameEnded)
		{
			RestartGame();
		}
	}

	void StartGame()
	{
		if (Input.GetButtonDown("Submit"))
		{
			_hasGameStarted = true;
			_callToAction_Start.enabled = false;
			Time.timeScale = 1f;
		}
	}

	void EndGame()
	{
		_countDown -= Time.deltaTime;

		int remainingTime = Mathf.RoundToInt(_countDown);
		_countDownDisplay.text = remainingTime + _countDownText;
		
		if (_countDown <= Mathf.Epsilon && !_hasGameEnded)
		{
			Time.timeScale = 0f;
			_callToAction_Start.enabled = true;
			_callToAction_Start.text = "Press Space to Start Over.";
			_hasGameEnded = true;
		}
	}

	void RestartGame()
	{
		if (Input.GetButtonDown("Submit"))
		{
			_countDown = _gameTime;
			_hasGameStarted = true;
			_hasGameEnded = false;
			_asteroidSpawner.CleanUpAndRestart();
			_scoreManager.ResetScore();

			Time.timeScale = 1f;
			_callToAction_Start.enabled = false;

			Missile[] missiles = FindObjectsOfType<Missile>();
			foreach (Missile missile in missiles)
			{
				Destroy(missile.gameObject);
			}
		}
	}
}
