using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    private int score;
    public Vector3 spawnValues;

    //Stuff for game over.
    //public Text restartText;
    public Text gameOverText;
    public GameObject restartButton;
    private bool gameOver;
    private bool restart;

    //Fun adds for me.
    private int waveSizeCounter = 0;
    private int spawnSpeedCounter = 0;

    private void Start()
    {
        gameOver = false;
        restart = false;
        //restartText.text = "";
        restartButton.SetActive(false);
        gameOverText.text = "";

        score = 0;
        updateScore();
        StartCoroutine (spawnWaves());
    }

    //private void Update()
    //{
    //    if(restart)
    //    {
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        }
    //    }
    //}

    private void updateScore()
    {
        scoreText.text = "Score " + score;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

    public void addScore(int newScore)
    {
        score += newScore;
        updateScore();
    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            //Check to see if we've reached the maximum wave size.
            if (hazardCount <= 25)
            {
                //Go head and work on increasing the wave size.
                waveSizeCounter++;
                if (waveSizeCounter > 2)
                {
                    waveSizeCounter = 0;
                    hazardCount++;
                }
            }

            //Check to see if the spawn time is at the mininum yet.
            if (spawnWait <= .03f)
            {
                //Go ahead and work on shortening the spawn time.
                spawnSpeedCounter++;
                if (spawnSpeedCounter > 3)
                {
                    spawnSpeedCounter = 0;
                    spawnWait = spawnWait - 0.1f;
                }
            }

            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                restartButton.SetActive(true);
                restart = true;
                break;
            }
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Try again hero!";
        gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
