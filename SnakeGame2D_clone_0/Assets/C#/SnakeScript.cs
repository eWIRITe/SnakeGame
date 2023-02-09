using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeScript : NetworkBehaviour
{

    public float Speed;
    public float RotationSpeed;

    public int startSize;

    public float MaxDistance;

    public GameObject PicePref;

    public int ClientNumber;

    
    public void Awake()
    {
        if (!isOwned) { return; }

        ClientNumber = GameObject.Find("GameManager").GetComponent<GameManager>().CountOfPlayers;

        GameObject.Find("GameManager").GetComponent<GameManager>().CountOfPlayers += 1;

        if (ClientNumber == 0)
        {
            GameManager.Player1.Add(gameObject.transform);
        }
        else if(ClientNumber == 1)
        {
            GameManager.Player2.Add(gameObject.transform);
        }
        

        for (int u = 0; u < startSize; u++)
        {
            AddPice();
            Debug.Log("Adding");
        }
    }


    public void FixedUpdate()
    {
        if(!isOwned) { return; }

        gameObject.transform.Translate(0, Speed * Time.deltaTime, 0);

        gameObject.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * RotationSpeed * -1);
    }

    [Command]
    public void AddPice()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddSnakePice(ClientNumber, PicePref);
    }
}
