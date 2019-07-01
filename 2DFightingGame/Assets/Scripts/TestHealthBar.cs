/*
Date of creation: July 1, 2019
Date of modification: July 1, 2019
Author: Max Wong
Purpose: To test and see if the HealthBar script is working
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthBar : MonoBehaviour
{

    //initializing a reference to the HealthBar script
    [SerializeField] private HealthBar healthBar;

    //Defining a variable used to modify the bar's values
    public float barSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Originally set the value of the bar to %100
        healthBar.SetSize(1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Continually update the value of the bar using the variable
      healthBar.SetSize(barSize);  

        //If player jumps, the bar will reduce by %20
      if(Input.GetButtonDown("Jump") == true)
      {
        barSize -= 0.2f;
      }
    }
}
