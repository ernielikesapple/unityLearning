using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource gunShotsSound;

    public float damage =  10f; // use the Raycasts shooting mechanism
    public float range = 100f; // change this var to adjust how far the gun can hit
    // public float fireRate = 15f;  // for shotting mutiple times
    public float impactForce = 30f;

    public Camera fpsCamera;  // shoot a ray starting at the position of the camera
    public ParticleSystem muzzelFlash;  // the explosive effect in the gun
    public GameObject impactEffect; // the gun effect when the gun hit sth

    // private float nextTimeToFire = 0f; //  for shotting mutiple times

    // Start is called before the first frame update
    void Start()
    {
        gunShotsSound = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)  for shotting mutiple times
        if (Input.GetMouseButtonDown(0))
        {
            // nextTimeToFire = Time.time + 1f / fireRate;   //  for shotting mutiple times
            Shoot();
        }
        
    }

    void Shoot() {

        // bullet sections
        GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject(); // pre initialized bullets from ObjectPool.cs
        newBullet.transform.position = transform.position + transform.up; // when instantiate let the bullet appear right in front of the gun
        newBullet.GetComponent<Rigidbody>().velocity = transform.up * 40;
        newBullet.SetActive(true);
        gunShotsSound.Play();


        muzzelFlash.Play();

        RaycastHit hit;  // var to hold the info about what we hit

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)) {
            // start at the position of the fpsCamera, towards the front, output all the info into the var hit, with the range in range var,
            // return true if we hit sth
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);

                float distance = Vector3.Distance(fpsCamera.transform.position, enemy.transform.position);
                Debug.Log("SADFDSFDGFD=====" + distance);

            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Debug.Log(hit.transform.name);

    
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));  // take a direction and turn it into a quaternion and 
            Destroy(impactGO, 2f);

        }


    }
}
