using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{

    float mouseSensitivity = 1000f;  // the bigger the more flexible the camera is 
    public Transform playerBody;  // assigned to the FPSController, inside the FPSController, they have added a character controller already.

    float xRotation = 0f; // todo::verify what these code does ?????

    public Camera fpsCamera;  // shoot a ray starting at the position of the camera
    public GameObject crosshair;

    public RawImage[] crosshairImagesArray;

    // Start is called before the first frame update
    void Start()
    {
        crosshairImagesArray = crosshair.GetComponentsInChildren<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // gives a changing value per second instead of per frame make it more sooth
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  // gives a changing value per second instead of per frame make it more sooth

        if (Input.GetMouseButton(0)) {
            playerBody.Rotate(Vector3.up * mouseX);   // rotate along the y    when the user try to move the camera left and right


            xRotation -= mouseY; // todo::verify what these code does ?????
            // xRotation = Mathf.Clamp(xRotation, -90, 90);  // give xRotation a restrain
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // todo::verify what these code does ?????,  when the user try to move the camera up and down

        }

        RaycastHit hit;  // var to hold the info about what we hit

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
        {
            // start at the position of the fpsCamera, towards the front, output all the info into the var hit, with the range in range var,
            // return true if we hit sth
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                // todo: change the color of
                
                
                float distance = Vector3.Distance(fpsCamera.transform.position, enemy.transform.position);
                Debug.Log("SADFDSFDGFD=====" + distance);

                if (distance < 7) // todo: if the distance smaller than 5f, make the crosshair bigger
                {
                   foreach (RawImage im in crosshairImagesArray)
                    {
                        im.GetComponent<RawImage>().color = Color.red;    
                    }

                   // crosshair.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
                    crosshair.transform.localScale = new Vector3(2, 2, 1);
                    //crosshair.transform.position = new Vector3(0, 0, 0);
                    //new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);

                }
                else
                {
                    foreach (RawImage im in crosshairImagesArray)
                    {
                        im.GetComponent<RawImage>().color = Color.white;
                    }
                    crosshair.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                foreach (RawImage im in crosshairImagesArray)
                {
                    im.GetComponent<RawImage>().color = Color.white;
                }
                crosshair.transform.localScale = new Vector3(1, 1, 1);
            }

        }




    }
}
