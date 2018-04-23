using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Prefab for instantiating enemies.
    public GameObject[] EnemyShips;

    //Speed at which the boss moves.
    public float speed = 1f;

    //Distance where the boss turns around
    public float leftAndRightEdge = 2f;

    //Distance down the screen the boss will travel.
    public float bottomEdge = 10f;

    //Chance that the boss will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which enemiles will be instantiated
    public float secondsBetweenEnemyDrops = 1f;

    public float enemyDropOffset = 4f;

    
    // Use this for initialization
    void Start()
    {
        //Dropping enemies every second.
        Invoke("DropEnemy", 2f);

    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        //Check for z direction to stop this at a certain point on the screen.
        if(pos.z > bottomEdge)
        {
            pos.z += -Mathf.Abs(speed) * Time.deltaTime;
        }


        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            //Move right.
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            //Move left.
            speed = -Mathf.Abs(speed);
        }

    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            //Change direction.
            speed *= -1;
        }
    }

    private void DropEnemy()
    {
        GameObject newEnemy = EnemyShips[Random.Range(0, EnemyShips.Length)];
        Vector3 spawnPosition = new Vector3(transform.position.x+ enemyDropOffset, transform.position.y, transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(newEnemy, spawnPosition, spawnRotation);
        //Change the side of the ship we'll drop on the next spawn.
        enemyDropOffset *= -1;
        Invoke("DropEnemy", secondsBetweenEnemyDrops);
    }
}
