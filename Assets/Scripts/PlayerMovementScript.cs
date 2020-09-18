using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    // version 1
    
    public CharacterController gameProtagonist;    // 游戏主角

    
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");  // controller pour à gauche et à droit
        float z = Input.GetAxis("Vertical");
        // below is move direciton
        Vector3 move = transform.right * x + transform.forward * z;  // transform.forward , make sure after the camera moves the protagonist always face the front


        gameProtagonist.Move(move / 10 );
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
