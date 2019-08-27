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

    // Update is called once per frame
    void Update()
    {


        if( !hasAuthority )
        {
            return;
        }

        if(Input.GetButtonDown("Jump"))
        {
            this.transform.Translate(new Vector2(0,1) * 10 * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }

    }
}
