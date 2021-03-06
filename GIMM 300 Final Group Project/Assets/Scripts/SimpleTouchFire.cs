﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchFire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    //Turning this into a singleton because it's not working for some reason.
    public static SimpleTouchFire Instance { get; private set; }

    private bool touched;
    private int pointerId;
    private bool canFire;

    void Awake()
    {
        //Check to see if there is something inside the instance property.  If not, it is new.
        if (Instance == null)
        {
            //Set the Instance property to the current this actual instance is.
            Instance = this;
            touched = false;
        }
        else
        {
            //There is already an instance of this script, so destroy the instance just created.
            Destroy(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!touched)
        {
            //Say that we were touched and track the touch.
            touched = true;
            pointerId = data.pointerId;

            //Set our ability to fire.
            canFire = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == pointerId)
        {
            touched = false;
            canFire = false;
        }
    }

    public bool CanFire()
    {
        return canFire;
    }
}
