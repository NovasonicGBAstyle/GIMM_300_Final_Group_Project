using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private float bgz;
    private Rigidbody rb;
    public GameObject bg1;
    public GameObject bg2;
    public float scrollSpeed = 1f;

	// Use this for initialization
	void Start () {
        //backgroundCollider = bg1.GetComponent<BoxCollider>();
        bgz = bg1.GetComponent<Renderer>().bounds.size.z;
        Debug.Log("bgz:" + bgz);

        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        //Start the object moving.
        bg1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, scrollSpeed*-1);
        bg2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, scrollSpeed*-1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (bg1.transform.position.z < -bgz)
        {
            RepositionBackground(bg1);
        }
        if (bg2.transform.position.z < -bgz)
        {
            RepositionBackground(bg2);
        }
    }

    private void RepositionBackground(GameObject go)
    {
        Vector3 backgroundOffset = new Vector3(0, -10, bgz);
        go.transform.position = backgroundOffset;

    }
}
