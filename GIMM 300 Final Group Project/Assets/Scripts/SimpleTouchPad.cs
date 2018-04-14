using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    //Turning this into a singleton because it's not working for some reason.
    public static SimpleTouchPad Instance { get; private set; }

    private Vector2 origin;
    public static Vector2 moveDirection;
    
    void Awake()
    {

        //Check to see if there is something inside the instance property.  If not, it is new.
        if (Instance == null)
        {
            //Set the Instance property to the current this actual instance is.
            Instance = this;
            DontDestroyOnLoad(gameObject);

            moveDirection = Vector2.zero;
        }
        else
        {
            //There is already an instance of this script, so destroy the instance just created.
            Destroy(gameObject);
        }
    }

    public void OnPointerDown (PointerEventData data)
    {
        //Set our start point.
        origin = data.position;
    }

    public void OnPointerUp(PointerEventData data)
    {
        //Reset everyting.
        moveDirection = Vector2.zero;
    }

    public void OnDrag(PointerEventData data)
    {
        //Compare the difference between our start point and our current pointer position
        Vector2 currentPosition = data.position;
        Vector2 directionRaw = currentPosition - origin;

        //Again, this will set the value to 1, but keep the direction.
        moveDirection = directionRaw.normalized;
        Debug.Log(moveDirection);
    }

    public Vector2 GetDirection()
    {
        Debug.Log(moveDirection);
        return moveDirection;
    }
}
