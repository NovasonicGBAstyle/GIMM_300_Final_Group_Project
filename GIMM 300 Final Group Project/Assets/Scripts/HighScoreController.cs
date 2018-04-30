using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public InputField PlayerNameText;
    public Text CurrentScoreText;
    public Text ScoreText;
    public GameObject saveButton;
    public GameObject backToMainButton;
    public GameObject restartButton;
    public FirebaseDatabaseHandler databaseHandler;

	// Use this for initialization
	void Awake ()
    {
        backToMainButton.SetActive(false);
        restartButton.SetActive(false);
        string playerName = "";
        playerName = PlayerPrefs.GetString("PlayerName", "Nameless Hero");

        //There is a player name, so populate the data with the player name.
        PlayerNameText.text = playerName;

        //Check to see if there is a current score.
        if (!PlayerPrefs.HasKey("CurrentScore"))
        {
            //No current score.  Set the current score to 0.
            PlayerPrefs.SetInt("CurrentScore", 0);
        }

        //Set the current score hidden text to the saved CurrentScore.  The code Dr. Dan
        //had us modify did this, and I just don't want to change it anymore.  Plus
        //PlayerPrefs isn't the best but I don't care to try and fix it right now
        //to use anything better.
        CurrentScoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();

        ScoreText.text = "Score " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }

    public void SavePlayerName()
    {
        saveButton.SetActive(false);
        PlayerNameText.gameObject.SetActive(false);
        backToMainButton.SetActive(true);
        restartButton.SetActive(true);
        PlayerPrefs.SetString("PlayerName", PlayerNameText.text);
        databaseHandler.AddScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackToMain()
    {
        Debug.Log("Back to main");
        SceneManager.LoadScene("Start Menu");
    }
}
