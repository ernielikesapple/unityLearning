using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource gunShotsSound;

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
            newBullet.GetComponent<Rigidbody>().velocity = transform.up * 25 ;
            newBullet.SetActive(true);
            gunShotsSound.Play();
        }
        
    }
}
