using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    public Text PlayerNameText;
    public Text CurrentScoreText;

	// Use this for initialization
	void Start () {
        //Check to see if there is a saved player name.
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            //There is a player name, so populate the data with the player name.
            PlayerNameText.text = PlayerPrefs.GetString("PlayerName");
        }

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
	}

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", PlayerNameText.text);
    }
}
