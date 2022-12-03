using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchProjectile : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject target;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2.5)
        {
            time = 0;
            transform.LookAt(target.transform);
            GameObject t = (GameObject)Instantiate(Projectile, transform.position, Quaternion.identity);
            Destroy(t, 3);
            t.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        }
    }
}
