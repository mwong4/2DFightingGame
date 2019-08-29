/*
Date of creation: Aug 27, 2019
Date of modification: Aug 27, 2019
Author: Max Wong
Purpose: A PlayerUnit is a unit controlled by a player
        This could be a character in an FPS, a zergling in a RTS
        or a scout in a TBS

Following "Unity MULTIPLAYER Tutorial -- Episode (1,2,3,4)"
URL: https://www.youtube.com/watch?v=cQ0f1_Ct9lc
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector2 velocity;

    //The position we think is mst correct for this player
    //note: if we are the authority, then this will be
    //exactly the same as transform.position

    Vector2 bestGuessPosition;

    //This is a constantly updated vae about our latency to this server
    //ie how many seconds it takes for us to recieve a one-way message
    float ourLatency; //TODO this should probably somethingw e get from the player connection object

    //The higher this value, the faster our local position will match the best guess position
    float LatencySmoothingFactor = 10;

    // Update is called once per frame
    void Update()
    {

        //code running right here is running for all versions of this object, even
        //if it's not the authoritative object
        //but even if we are not the owner, we are tryng to predict where th object
        //shoud be right now, based on the last velocity update


        if( !hasAuthority )
        {
                //We are not the authority of the object, but we still need to update
                //our local position based on our best guess of where
                //it probaly is on the owners screen

                bestGuessPosition = bestGuessPosition + (velocity * Time.deltaTime);

                //Instead of teleporting our position to the best guess
                //we can smoothly lerp to it.

                transform.position = Vector2.Lerp (transform.position, bestGuessPosition, Time.deltaTime * LatencySmoothingFactor);

            return;
        }

        //If we get to here, we are the authoritative of the object
         this.transform.Translate( velocity * Time.deltaTime );

        if(Input.GetButtonDown("Jump"))
        {
            this.transform.Translate(new Vector2(0,1) * 10 * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }

        if( true )
        {
                //change velocity

                velocity = new Vector2(1,0);

                CmdUpdateVelocity(velocity, transform.position);
        }

    }

    [Command]
    void CmdUpdateVelocity(Vector2 v, Vector2 p)
    {
        //I am on a server
        transform.position = p;
        velocity = v;

        //If we know what our current latency is, we could do something like this
        //transformposition = p + (v * theirlatency)

        //Now let the clients know the current position of this upject
        RpcUpdateVelocity( velocity, transform.position);

    }

    [ClientRpc]
    void RpcUpdateVelocity(Vector2 v, Vector2 p)
    {
        //I am on a client

        if( hasAuthority )
        {
            //Hey, this is my object. I should already have the most accurate
            //position/velocity (possibly more acureate) than the server
            //Depending on the game, I might want to change to patch this info
            //from the server, even though that might look a little wonky to the user

            //Let's assume for now that we are going to ignore message from server

            return;
        }

        //I am a none-authorative client, so I defin itely need to listen to the server.

        //If we know what our current latency is, we could do something like this
        //transformposition = p + (v * ourlatency )

        //transform.position = p;

        velocity = v;
        bestGuessPosition = p + (velocity * ourLatency );


        //Now position of player 1 is as close as possible to all player's screens

        //In fact, we dont want to directly update transform.position, because then
        //players will keep teleporting/blinking around. dumb.
    }

}
