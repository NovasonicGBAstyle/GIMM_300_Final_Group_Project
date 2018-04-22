using System.Collections;
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

        //First, destroy what hit this.  Like a bolt.
        Destroy(other.gameObject);

        //Next, determine if this has been destroyed.
        hitPoints--;

        if(hitPoints <= 0)
        {

        }

    }
}