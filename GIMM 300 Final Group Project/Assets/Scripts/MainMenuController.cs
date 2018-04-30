using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    public Camera camera;
	// Use this for initialization
	void Awake () {
        Debug.Log("Setting camera dealio");
        Debug.Log(Screen.width);
        float newRatio= 640 / Screen.width * Screen.height / 2;
        Debug.Log(newRatio);
        camera.orthographicSize = newRatio;

    }
}
