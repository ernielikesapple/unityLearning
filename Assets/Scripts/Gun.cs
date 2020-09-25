using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource gunShotsSound;

    public float damage =  10f; // use the Raycasts shooting mechanism
    public float range = 100f; // change this var to adjust how far the gun can hit


    public Camera fpsCamera;  // shoot a ray starting at the position of the camera  
    // Start is called before the first frame update
    void Start()
    {
        gunShotsSound = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject(); // pre initialized bullets from ObjectPool.cs
            newBullet.transform.position = transform.position + transform.up; // when instantiate let the bullet appear right in front of the gun
            newBullet.GetComponent<Rigidbody>().velocity = transform.up * 40 ;
            newBullet.SetActive(true);
            gunShotsSound.Play();

            Shoot();


        }
        
    }

    void Shoot() {
        RaycastHit hit;  // var to hold the info about what we hit

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)) {
            // start at the position of the fpsCamera, towards the front, output all the info into the var hit, with the range in range var,
            // return true if we hit sth
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) {
                Debug.Log("?????????????");
                enemy.TakeDamage(damage);

            }

            Debug.Log(hit.transform.name);
              
        }


    }
}
