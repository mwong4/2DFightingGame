/*
Date of creation: July 1, 2019
Date of modification: July 1, 2019
Author: Max Wong
Purpose: To allow the changing of the transformations of the healthbar object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

//Define a variable containing the transform "bar"
    private Transform bar;

    // Start is called before the first frame update
    private void Start()
    {
        //set the transform as the object named "bar"
        bar = transform.Find("Bar");
        //bar.localScale = new Vector3(0.4f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //A function that can be called by other scripts to modify the bar size
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
