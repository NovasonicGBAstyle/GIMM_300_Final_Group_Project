using UnityEngine;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("fire", delay, fireRate);
	}

    void fire()
    {
        //Instantiate shot at shot spawn.
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
