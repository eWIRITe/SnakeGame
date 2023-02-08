using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public static int NumberOfClients;

    public static List<Transform> Player1 = new List<Transform>();
    public static List<Transform> Player2 = new List<Transform>();

    
    // Update is called once per frame
    public void MoovePices(int NumberOfPlayer)
    {
        if (NumberOfPlayer == 0) 
        {
            
            for (int i = 1; i < Player1.Count; i++)
            {

                Transform thisObj = Player1[i];

                Transform lastObj = Player1[i - 1];

                Vector2 direction = lastObj.transform.position - thisObj.transform.position;

                thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

                float Dis = Vector2.Distance(lastObj.position, thisObj.position);

                if (0.2f < Dis) { thisObj.transform.Translate(0, Dis - 0.2f, 0); }
            }
        }

        else if (NumberOfPlayer == 1)
        {
            for (int i = 1; i < Player2.Count; i++)
            {
                Transform thisObj = Player2[i];


                Transform lastObj = Player2[i - 1];

                Vector2 direction = lastObj.transform.position - thisObj.transform.position;

                thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

                float Dis = Vector2.Distance(lastObj.position, thisObj.position);

                if (0.2f < Dis) { thisObj.transform.Translate(0, Dis - 0.2f, 0); }
            }
        }

        else Debug.Log("incorrectNumber");
    }

    public void AddSnakePice(int NumberOfPlayer, GameObject PicePref)
    {

        if (NumberOfPlayer == 0) 
        { 
            var newObj = Instantiate(PicePref);

            Player1.Add(newObj.transform);

            NetworkServer.Spawn(newObj);
        }
        else if (NumberOfPlayer == 1)
        {
            var newObj = Instantiate(PicePref);

            Player2.Add(newObj.transform);

            NetworkServer.Spawn(newObj);
        }

        else { Debug.Log("sorri, it is incorrect number"); }
    }
}
