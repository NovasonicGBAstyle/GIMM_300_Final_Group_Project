using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gc;
    private GameObject target;

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
        target = other.gameObject;
        if(other.transform.parent != null)
        {
            target = other.transform.parent.gameObject;
        }
        //GameObject target = other.transform.parent.gameObject;
        //Debug.Log(other.name);
        //Debug.Log(target.name);

        //So, we're going to check to see if we are hitting the bondary, or an enemy.
        if (target.CompareTag("Boundary") || target.CompareTag("Enemy"))
        {
            return;
        }

        //Debug.Log(target.name);
        //First, destroy what hit this.  Like a bolt.
        Destroy(target.gameObject);

        //Now, destroy this asteroid
        Destroy(gameObject);

        //Only do the explosion if we have one.
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        gc.addScore(scoreValue);

        if(target.tag == "Player")
        {
            Instantiate(playerExplosion, target.transform.position, target.transform.rotation);
            gc.GameOver();
        }
    }
}
