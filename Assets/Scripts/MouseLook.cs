using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    float mouseSensitivity = 1000f;  // the bigger the more flexible the camera is 
    public Transform playerBody;  // assigned to the FPSController, inside the FPSController, they have added a character controller already.

    float xRotation = 0f; // todo::verify what these code does ?????


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // Time.deltaTime, the usage to be verifed
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  // Time.deltaTime, the usage to be verifed

        if (Input.GetMouseButton(0)) {
            playerBody.Rotate(Vector3.up * mouseX);   // rotate along the y    when the user try to move the camera left and right


            xRotation -= mouseY; // todo::verify what these code does ?????
            // xRotation = Mathf.Clamp(xRotation, -90, 90);  // give xRotation a restrain
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // todo::verify what these code does ?????,  when the user try to move the camera up and down

        }

        

    }
}
