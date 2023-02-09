using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    //lists for 2 players
    public static List<Transform> Player1 = new List<Transform>();
    public static List<Transform> Player2 = new List<Transform>();

    // Update is called once per frame
    public void FixedUpdate()
    {
        //mooving snakes bodyes

        for (int i = 1; i < Player1.Count; i++)
        {
            //get pices
            Transform thisObj = Player1[i];
            Transform lastObj = Player1[i - 1];


            Vector2 direction = lastObj.transform.position - thisObj.transform.position;

            //rotate thisObj to last object
            thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            //count the distance
            float Dis = Vector2.Distance(lastObj.position, thisObj.position);

            //if we do need to moove the pice, we do it
            if (0.2f < Dis) { thisObj.transform.Translate(0, Dis - 0.2f, 0); }
        }

        for (int k = 1; k < Player2.Count; k++)
        {
            //get pices
            Transform thisObj = Player2[k];
            Transform lastObj = Player2[k - 1];


            Vector2 direction = lastObj.transform.position - thisObj.transform.position;

            //rotate thisObj to last object
            thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            //count the distance
            float Dis = Vector2.Distance(lastObj.position, thisObj.position);

            //if we do need to moove the pice, we do it
            if (0.2f < Dis) { thisObj.transform.Translate(0, Dis - 0.2f, 0); }
        }
    }

    [Server]
    public void AddSnakePice(int NumberOfPlayer, GameObject PicePref)
    {
        //add the body pices to snakes

        if (NumberOfPlayer == 0) 
        { 
            //create new object
            var newObj = Instantiate(PicePref);

            //add ne object to list
            Player1.Add(newObj.transform);

            //spawn object on the server
            NetworkServer.Spawn(newObj);
        }

        else if (NumberOfPlayer == 1)
        {
            //create new object
            var newObj = Instantiate(PicePref);

            //add ne object to list
            Player2.Add(newObj.transform);

            //spawn object on the server
            NetworkServer.Spawn(newObj);
        }

        else { Debug.Log("sorry, it is incorrect number"); }
    }
}
