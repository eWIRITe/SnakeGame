using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public static List<Transform> Player1 = new List<Transform>();
    public static List<Transform> Player2 = new List<Transform>();

    public int CountOfPlayers = 0;

    // Update is called once per frame
    public void FixedUpdate()
    {
        Debug.Log(Player1.Count);
        Debug.Log(Player2.Count);

        for (int i = 1; i < Player1.Count; i++)
        {
            Transform thisObj = Player1[i];

            Transform lastObj = Player1[i - 1];

            Vector2 direction = lastObj.transform.position - thisObj.transform.position;

            thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            float Dis = Vector2.Distance(lastObj.position, thisObj.position);

            if (0.2f < Dis) { thisObj.transform.Translate(0, Dis - 0.2f, 0); }
        }

        for (int k = 1; k < Player2.Count; k++)
        {
            Transform thisObj = Player2[k];

            Transform lastObj = Player2[k - 1];

            Vector2 direction = lastObj.transform.position - thisObj.transform.position;

            thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            float Dis = Vector2.Distance(lastObj.position, thisObj.position);

            if (0.2f < Dis) { thisObj.transform.Translate(0, Dis - 0.2f, 0); }
        }
    }

    [Server]
    public void AddSnakePice(int NumberOfPlayer, GameObject PicePref)
    {
        Debug.Log("your nOf = " + NumberOfPlayer);

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

        else { Debug.Log("sorry, it is incorrect number"); }
    }
}
