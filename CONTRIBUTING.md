PROJECT CODE OF CONDUCT
This document is intended as a guide to how the product should be developed



Visual Component

Art should be stored in the designated folder

Art should conform to the designated art style (TBD)

Add any planned work onto the "Timeline" as a goal for the week

If you require any work, go to the to do list and find some
If you have finished any work, go to the to do list and update the list + find more work



Coding

Code should be stored in the designated folders

Operations should be spaced out ( firstValue  !=  4  &&  firstValue  >=  2 )

Variables must be descriptive and camelCase

Order of code should be like this
Header (Date of creation, Date of modification, Author, Brief description of this program’s purpose
Any included libraries (like using UnityEngine;)
Function prototypes
Global variables
Start and Update function
Other custom functions
Curly brackets should be in A-style and content inside should be indented
While ( iAmCool == true) 
{
        Debug.Log(“I am still cool”);
}

Example:
/*
Date of creation: Apr 8, 2013
Date of modification: Apr 8, 2013
Author:UNITY
Purpose: To show the basic conventions and syntax
*/
using UnityEngine;
using System.Collections;

public class basicSyntax : MonoBehaviour
{
    void Start ()
    {
        Debug.Log(transform.position.x);
        
        if(transform.position.y <= 5f)
        {
            Debug.Log ("I'm about to hit the ground!");
        }
    }
}
Reference

Add any planned work onto the "Timeline" as a goal for the week

If you require any work, go to the to do list and find some
If you have finished any work, go to the to do list and update the list + find more work


GitHub/Source Control

ALWAYS make a branch before making changes. DO NOT commit straight to master branch.

If a UNITY game is being made, do not work on the same scene as someone else. Data will be lost. Coordinate with the other developer.

When merging files, make sure to know what has been added (either by comments or asking the developer)

Let everybody know what you are working on (and maybe what branch) before starting.

Make sure the branch names are descriptive (and camelCase).

Make sure the commit comments are descriptive.

If you have trouble, contact a designated Source Control moderator.
