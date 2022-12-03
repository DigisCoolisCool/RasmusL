using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangeNPC : MonoBehaviour
{
    private int Health;
    public GameObject smoke;
    public AudioSource[] sounds;
    public AudioSource NPCdestroySound;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        NPCdestroySound = sounds[0];
    }

    public void gotHit()
    {
        Health = -25;
    }
    private void Destroy()
    {
        GameObject lastSmoke = (GameObject)(Instantiate(smoke, transform.position, Quaternion.identity));
        Destroy(lastSmoke, 3);
        Destroy(gameObject);
        NPCdestroySound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) Destroy();   
    }
}
