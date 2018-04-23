using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroyByContact : MonoBehaviour{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int hitPoints = 5;
    public float hitTimer = 2f;
    private float lastHitTime = 0f;
    private GameController gc;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gc = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //So, we're going to check to see if we are hitting the bondary, or an enemy.
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        //Debug.Log(other.name);
        //First, destroy what hit this.  Like a bolt.
        Destroy(other.gameObject);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gc.GameOver();
        }

        takeHit(other);
    }

    /// <summary>
    /// This function is going to check and see if the boss can take damage.  It will be 
    /// speficially to make it seem harder to kill.
    /// </summary>
    /// <param name="other">Collider of thing that was hit.</param>
    private void takeHit(Collider other)
    {

        //First, see if this is within the time frame of the last shot so that we don't do damage.
        if (Time.time - lastHitTime < hitTimer) return;

        //Debug.Log("We are now hitting this boss!");
        //Debug.Log("BOSS HP:" + hitPoints.ToString());

        //Set last timer for next check.
        lastHitTime = Time.time;

        //Next, determine if this has been destroyed.
        hitPoints--;

        if (hitPoints <= 0)
        {

            //Now, destroy this boss
            Destroy(gameObject);

            gc.killBoss();
            gc.addScore(scoreValue);

            //Only do the explosion if we have one.
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }
}