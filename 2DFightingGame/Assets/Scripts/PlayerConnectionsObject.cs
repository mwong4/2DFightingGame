/*
Date of creation: Aug 26, 2019
Date of modification: Aug 27, 2019
Author: Max Wong
Purpose: To hold and modify basic values of the player. To experiment with networking.

Following "Unity MULTIPLAYER Tutorial -- Episode (1,2,3,4)"
URL: https://www.youtube.com/watch?v=cQ0f1_Ct9lc
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionsObject : NetworkBehaviour
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
       // Debug.Log("spawning the player unit");

        //Instantiate(PlayerUnitPrefab);

        // Command the server to spawn our unit
        CmdSpawnMyUnit();
    }

    public GameObject PlayerUnitPrefab;

    //SyncVar are ariales where if their values changes on the SERVER, then all clients
    // are automatically informed of the new values
    [SyncVar (hook="OnPlayerNameChanged")]
    public string PlayerName = "Anonymous";

    // Update is called once per frame
    void Update()
    {
            //Remeber: Update runs on EVERYONE"s computer, wether or not
            //they own this particular player object

        if( !isLocalPlayer )
        {
            return;
        }

        if( Input.GetKeyDown(KeyCode.S))
        {
            CmdSpawnMyUnit();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
           string n = "Quil" + Random.Range(1, 100); 
           Debug.Log("Sending the server a request to change our name to:  " + n );
           CmdChangePlayerName(n);

        }

        /*
        if(Input.GetButtonDown("Jump"))
        {
            CmdMoveUnitUp();
        }
        */
        
    }

    void OnPlayerNameChanged(string newName)
    {
        Debug.Log("OnPlayerNameChanged: OldName: " + PlayerName + " NewName: " + newName);

         //wARNING: If you ise a hook on a SyncVar, the our local value does NOT get automatically
         //updated.
        PlayerName = newName;

        gameObject.name = "PlayerConectionObject [" + newName + "]";
    }

    ///////////////////////// Commands
    // Commands are special functions that ONLT get executed on the server.

    [Command]
    void CmdSpawnMyUnit()
    {
        //We are guaranteed to be on the server right now.
        GameObject go = Instantiate(PlayerUnitPrefab);

        //go.GetComponent<NetworkIdentity>().AssignClientAuthority( connectionToClient );

        //Now that the object exists on ther server, propagate it to all
        //the clients (and also wire up the NetworkIdentity)
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);

    }

    [Command]
    void CmdChangePlayerName(string n)
    {
        PlayerName = n;
        //Debug.Log("New name: " + PlayerName );

        //Check for bad/error names?


        //RpcChangePlayerName(PlayerName);
    }



        ///////////////////////// RPC
        //RPCs are special functions that ONLY get executed on the clients.

        /*
        [ClientRpc]
        void RpcChangePlayerName(string n)
        {
            PlayerName = n;
        }
        */

    
}
