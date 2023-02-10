using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    
    public void AddSnakePice(GameObject PicePref, GameObject Player)
    {
        //add the body pices to snakes
        if (Player.transform == NetworkManager.Player1[0])
        {
            //create new object
            GameObject newObj = Instantiate(PicePref);

            //add ne object to list
            NetworkManager.Player1.Add(newObj.transform);

            //spawn object on the server
            NetworkServer.Spawn(newObj);
        }

        else if (NetworkManager.Player2.Count > 0)
        {
            if (Player.transform == NetworkManager.Player2[0])
            {
                //create new object
                GameObject newObj = Instantiate(PicePref);

                //add ne object to list
                NetworkManager.Player2.Add(newObj.transform);

                //spawn object on the server
                NetworkServer.Spawn(newObj);
            }
        }

    }
}
