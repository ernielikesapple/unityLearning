using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPratice : MonoBehaviour        // when renaming a file, reminder to changed the class name too!
{
    // public float rCubeCounter;
    public GameObject randomCube;

    public float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this is where the scene get initialised"); // 
    }

    // Update is called once per frame
    void Update()
    {
        //rCubeCounter += 0.1f;
        // // Debug.Log("Count= " + frameCounter++ ); // 
        // randomCube.transform.position = new Vector3(Mathf.Sin(rCubeCounter), Mathf.Cos(rCubeCounter), 0);
        if (Input.GetMouseButton(0)) {  // click the left mouse, 
            float h = rotateSpeed * Input.GetAxis("Mouse X");  // see the name in the Edit ->  Project Settings -> Input Manager -> Axes
            float v = rotateSpeed * Input.GetAxis("Mouse Y");
            randomCube.transform.Rotate(v, -h, 0,  Space.World);




        }



    }
}
