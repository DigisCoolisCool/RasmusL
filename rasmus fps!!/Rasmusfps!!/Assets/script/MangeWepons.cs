using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangeWepons : MonoBehaviour
{
    Camera playerCamera;
    Ray RayFromPlayer;
    RaycastHit hit;
    public GameObject sparksAtInpact;
    public int gunAmmo = 20;
    public AudioSource[] sounds;
    public AudioSource gunshot;
    public AudioSource ammopickup;
    public ParticleSystem MuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<Camera>();
        sounds = GetComponents<AudioSource>();
        gunshot = sounds[0];
        ammopickup = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        RayFromPlayer = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(RayFromPlayer.origin, RayFromPlayer.direction * 100, Color.red);

        if (Input.GetMouseButtonDown(0) && gunAmmo > 0)
        {
            if(Physics.Raycast(RayFromPlayer,out hit, 100))
            {
                print("The Object " +hit.collider.gameObject.name + " is in front of the player");
                Vector3 positionOfImpact;
                positionOfImpact = hit.point;
                Instantiate(sparksAtInpact, positionOfImpact, Quaternion.identity);
                GameObject objectTarget;
                if (hit.collider.gameObject.tag == "target")
                {
                    objectTarget = hit.collider.gameObject;
                    objectTarget.GetComponent<MangeNPC>().gotHit();
                }
            }
            gunAmmo--;
            print("you have" + gunAmmo + " bullets left ");
            gunshot.Play();
            MuzzleFlash.Play();

        }

       

    }
    public void manageCollisions(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "ammo_gun")
        {
            gunAmmo += 5;
            if (gunAmmo > 25) gunAmmo = 25;
            Destroy(hit.collider.gameObject);
            ammopickup.Play();
        }
    }



}
