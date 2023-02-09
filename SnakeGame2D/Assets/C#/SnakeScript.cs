using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeScript : NetworkBehaviour
{
    public float Speed;
    public float RotationSpeed;

    public int startSize;

    public GameObject PicePref;

    public int ClientNumber;


    public void Start()
    {
        if (!isOwned) { return; }

        //Get number of player
        GetNumberOfPlayers();

        //add head to list on GameManager
        if (ClientNumber == 0)
        {
            GameManager.Player1.Add(gameObject.transform);
        }
        else if (ClientNumber == 1)
        {
            GameManager.Player2.Add(gameObject.transform);
        }

        //create snake body
        for (int u = 0; u < startSize; u++)
        {
            AddPice();
            Debug.Log("Adding");
        }
    }


    public void FixedUpdate()
    {
        if (!isOwned) { return; }

        //moove head
        gameObject.transform.Translate(0, Speed * Time.deltaTime, 0);
        //rotate head
        gameObject.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * RotationSpeed * -1);
    }

    [Command]
    public void AddPice()
    {
        //call function from client on server
        GameObject.Find("GameManager").GetComponent<GameManager>().AddSnakePice(ClientNumber, PicePref);
    }


    [Command]
    public void GetNumberOfPlayers()
    {
        //не хороший костыль, to get the number of players
        ClientNumber = GameManager.Player1.Count >= 2 ? 1 : 0;
    }
}
