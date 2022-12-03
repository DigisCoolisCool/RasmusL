using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithProjectile : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource[] sound;
    public AudioSource explosionsound;

    // Start is called before the first frame update
    void Start()
    {
        explosionsound = sound[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject, 1);
            explosionsound.Play();
            Application.LoadLevel(Application.loadedLevel);
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosionsound.Play();
    }
}
