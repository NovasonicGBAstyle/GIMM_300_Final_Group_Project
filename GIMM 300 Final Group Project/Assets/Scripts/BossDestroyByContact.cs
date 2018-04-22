﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroyByContact : MonoBehaviour{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int hitPoints = 5;
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

        Debug.Log(other.name);
        //First, destroy what hit this.  Like a bolt.
        Destroy(other.gameObject);

        //Next, determine if this has been destroyed.
        hitPoints--;

        if(hitPoints <= 0)
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

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gc.GameOver();
        }

    }
}