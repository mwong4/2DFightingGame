/*
Date of creation: Aug 26, 2019
Date of modification: Aug 26, 2019
Author: Max Wong
Purpose: To hold and modify basic values of the player. To experiment with networking.

Following "Unity MULTIPLAYER Tutorial -- Episode (1,2,3,4)"
URL: https://www.youtube.com/watch?v=cQ0f1_Ct9lc
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Checking if this is my own local PlayerObject
        if ( !isLocalPlayer )
        {
            //This object belongs to another player
            return;
        }

        //Since the PlayerObject is invisible and not part of the world,
        //give me something physical to move around!

        //Spawning the unit
        Debug.Log("spawning the player unit");

        Instantiate(PlayerUnitPrefab);
    }

    public GameObject PlayerUnitPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }
}
