using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gc;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if(gameControllerObject != null)
        {
            gc = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //So, we're going to check to see if we are hitting the bondary, or an enemy.
        if(other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        //First, destroy what hit this.  Like a bolt.
        Destroy(other.gameObject);

        //Now, destroy this asteroid
        Destroy(gameObject);

        //Only do the explosion if we have one.
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        gc.addScore(scoreValue);

        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gc.GameOver();
        }
    }
}
