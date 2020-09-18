using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    // version 1
    
    public CharacterController gameProtagonist;    // 游戏主角

    public Transform goundCheck;
    public float groundDistance = 0.4f; // radius of sphere, the sphere of that empty object to detect whether we are touching the ground
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity; // verify this oart again 
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(goundCheck.position, groundDistance, groundMask);                      // return true if any colliders overlapping , check the position of groundMask and groundMask, if their distance less than groundDistance, then return true
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }




        float x = Input.GetAxis("Horizontal");  // controller pour à gauche et à droit
        float z = Input.GetAxis("Vertical");
        // below is move direciton
        Vector3 move = transform.right * x + transform.forward * z;  // transform.forward , make sure after the camera moves the protagonist always face the front


        gameProtagonist.Move(move / 10 );

        velocity.y += gravity * 1.8f * Time.deltaTime;
        gameProtagonist.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    
    



    // version 2
    /*
    public float moveSpeed = 15; // this number can be changed later

    private Vector3 moveDirection;

    void Update() {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }


    public void FixedUpate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
    */

}
