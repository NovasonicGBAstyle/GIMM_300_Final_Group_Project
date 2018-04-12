using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
    private Vector2 origin;
    private static Vector2 direction;
    
    void Awake()
    {
        //direction = Vector2.zero;
    }

    public void OnPointerDown (PointerEventData data)
    {
        //Set our start point.
        origin = data.position;
    }

    public void OnPointerUp(PointerEventData data)
    {
        //Reset everyting.
        //direction = Vector2.zero;
    }

    public void OnDrag(PointerEventData data)
    {
        //Compare the difference between our start point and our current pointer position
        Vector2 currentPosition = data.position;
        Vector2 directionRaw = currentPosition - origin;

        //Again, this will set the value to 1, but keep the direction.
        Vector2 direction = directionRaw.normalized;
        Debug.Log(direction);
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
