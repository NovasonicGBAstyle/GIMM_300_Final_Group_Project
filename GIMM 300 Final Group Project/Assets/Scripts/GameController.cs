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

    //Boss stuff.
    public GameObject[] Bosses;
    public int bossWaveCount;       //How many waves between boss spawns
    private int waveCounter;        //How many waves we have had.
    private bool bossWave;          //Whether this is a boss wave or not.

    private void Start()
    {
        gameOver = false;
        restart = false;
        //restartText.text = "";
        restartButton.SetActive(false);
        gameOverText.text = "";

        score = 0;
        updateScore();

        bossWave = false;
        waveCounter = 0;
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
            Debug.Log("Boss waive check: " + bossWave);
            Debug.Log("Wave counter: " + waveCounter);
            if (!bossWave)
            {
                if (waveCounter >= bossWaveCount)
                {
                    Debug.Log("we need to build a boss");
                    //We need to spawn a boss.
                    waveCounter = 0;
                    bossWave = true;
                    //Boss spawn.  We currently only have one, but I'll just build it so that we can have more.
                    GameObject boss = Bosses[Random.Range(0, Bosses.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.Euler(0, 170, 0);
                    Instantiate(boss, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                else
                {
                    Debug.Log("Not a boss wave.");
                    for (int i = 0; i < hazardCount; i++)
                    {
                        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                        Quaternion spawnRotation = Quaternion.identity;
                        Instantiate(hazard, spawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);

                    }
                    waveCounter++;
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
            }
            else
            {
                Debug.Log("This in the middle of a boss wave.  Here we go!");
                yield return new WaitForSeconds(waveWait);
            }

            if (gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                restartButton.SetActive(true);
                restart = true;
                break;
            }
        }
    }

    public void killBoss()
    {
        Debug.Log("Boss killed");
        bossWave = false;
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
