using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisinWithPlayer : MonoBehaviour
{
    public int scoore;
    public AudioSource[] sounds;
    public AudioSource colectible;

    // Start is called before the first frame update
    void Start()
    {
        scoore = 0;
        colectible = sounds[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "colectible")
        {
            Destroy(other.gameObject);
            scoore++;
            print("scoore " + scoore);
            colectible.Play();
        }
    }
}
