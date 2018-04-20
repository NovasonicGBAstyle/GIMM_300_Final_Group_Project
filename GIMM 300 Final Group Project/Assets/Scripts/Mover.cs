using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Debug.Log("Velocity now:" + rb.velocity);
    }
}
