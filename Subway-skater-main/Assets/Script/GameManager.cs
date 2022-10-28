using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private const float COIN_SCORE_AMOUNT = 5.0f;

	public static GameManager Instance { set; get; }
	public bool IsDead { get; set; }

	private bool isGameStarted;
	private PlayerMotor motor;

	// UI
	public Text scoreText, coinText, modifierText, hiScoreText;
	private float score, lastScore, coinScore, modifierScore;
	public Animator deathanime;

	public Text deadscoreText, deadcoinText;
	public GameObject chatPanel, textObj;
	public Animator gameCanvas, menuCanvas, diamondCanvas;

	public GameObject connectedMenu, disconnectedMenu;
	List<string> dtext;

	public InputField field;
    internal static bool mute;

    private void Awake()
	{
		Instance = this;
		modifierScore = 1;

		scoreText.text = score.ToString ("0");
		coinText.text = coinScore.ToString ("0");
		modifierText.text = "x" + modifierScore.ToString ("0.0");

		motor = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMotor> ();
		hiScoreText.text = PlayerPrefs.GetInt("Hiscore").ToString();
	}

	private void Update()
	{
		if (MobileInput.Instance.Tap && !isGameStarted) {
			isGameStarted = true;
			motor.StartRunning ();
			FindObjectOfType<GlacierSpawner>().IsScrolling = true;
			FindObjectOfType<CameraMotor>().IsMoving = true;
			gameCanvas.SetTrigger("Show");
			menuCanvas.SetTrigger("Hide");
			


		}

		if (isGameStarted) {
			score += (Time.deltaTime * modifierScore);

			if (lastScore != (int)score) {
				lastScore = (int) score;
				scoreText.text = score.ToString ("0");
			}
		}
	}

	public void GetCoin()
	{
		diamondCanvas.SetTrigger("Collect");
		coinScore++;
		coinText.text = coinScore.ToString ("0");
		score += COIN_SCORE_AMOUNT;
		scoreText.text = score.ToString("0");

	}
		
	public void UpdateModifier(float modifierAmount)
	{
		modifierScore = 1.0f + modifierAmount;
		modifierText.text = "x" + modifierScore.ToString ("0.0");
	}


	public void onPlayButton()
    {
		FindObjectOfType<AudioManager>().Play("Soundland");
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

	public void OnDeath()
    {
		IsDead = true;
		FindObjectOfType<GlacierSpawner>().IsScrolling = false;
		deadscoreText.text = score.ToString("0");
		deadcoinText.text = coinScore.ToString("0");
		deathanime.SetTrigger("Dead");
		gameCanvas.SetTrigger("Hide");


		//check if  this is a highscore
		if(score >PlayerPrefs.GetInt("Hiscore"))
        {
			int s = (int)score;
			if (s % 1 == 0)
				s += 1;
			PlayerPrefs.SetInt("Hiscore",s);
        }

	}


	public void OnConnectClick()
    {
		Social.localUser.Authenticate((bool success)=>
			{
			OnconnectionReponse(success);
        });
    }

    private void OnconnectionReponse(bool authenticated)
    {
        if(authenticated)
		{
			connectedMenu.SetActive(true);
			disconnectedMenu.SetActive(false);
		}

		else
        {
			connectedMenu.SetActive(false);
			disconnectedMenu.SetActive(true);
        }

    }

	public void QuitGame()
    {
		Application.Quit();
    }
	
	public void PauseGame()
    {
		Time.timeScale = 0;
    }

	public void ResumeGame()

	{


		Time.timeScale = 1;
	}
	public void Restart()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
