/*
Date of creation: June 28, 2019
Date of modification: June 28, 2019
Author: Max Wong
Purpose: To get player inputs in order to perform movements through the "CharacterController2D".
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    //Various input methods for the fixed update function
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get player Input for horizontal movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Get player Input for jump button  
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }

        //Get player Input for crouch button
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    //Updates at a fixed rate
    void FixedUpdate() {
        //Reference player controller and input values
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
    }
}
