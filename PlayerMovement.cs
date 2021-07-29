using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 80f;
    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    bool hit = false;
    bool disXnY = false; //Disables X and Y Axis (bool check)
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {   
            
            jump = true;
            
        }
        
        if(controller.IsMushroomToJump() == true) {
            jump = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {

            crouch = true;

        }else if(Input.GetButtonUp("Crouch"))
        {

            crouch = false;
        }



        if(Input.GetButtonDown("Hit"))
        {
            disXnY = true;
            hit = true; 

            
            
        }else if (Input.GetButtonUp("Hit"))
        {
            disXnY = false;
            hit = false;

        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, hit, disXnY);
        hit = false;
        jump = false;
        
    }
}
