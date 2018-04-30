using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private float bgz;
    private Rigidbody rb;
    public GameObject bg1;
    public GameObject bg2;
    public float scrollSpeed = 1f;

    private Vector3 startPosition1;
    private Vector3 startPosition2;

    // Use this for initialization
    void Start () {
        //backgroundCollider = bg1.GetComponent<BoxCollider>();
        bgz = bg1.GetComponent<Renderer>().bounds.size.z;
        //Debug.Log("bgz:" + bgz);

        startPosition1 = bg1.transform.position;
        startPosition2 = bg2.transform.position;
    }
	
	// I really tried to get rid of that gap. It just wasn't happening man.
	void FixedUpdate ()
    {

        float newPosition1 = Mathf.Repeat(Time.time * scrollSpeed, bgz*2);
        float newPosition2 = newPosition1;
        if(newPosition1 <= bgz)
        {
            newPosition2 = newPosition1 + bgz;
        }
        else
        {
            newPosition2 = newPosition1 - bgz;
        }

        bg1.transform.position = startPosition1+Vector3.forward * (newPosition1 * -1 + bgz);
        bg2.transform.position = startPosition2+Vector3.forward * (newPosition2 * -1 + bgz);
    }
}
