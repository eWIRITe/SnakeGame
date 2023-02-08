using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeScript : NetworkBehaviour
{
    public List<Transform> Pices = new List<Transform>();

    public float Speed;
    public float RotationSpeed;

    public int startSize;

    public float MaxDistance;

    public GameObject PicePref;

    public int ClientNumber;

    public void Start()
    {
        if (!isLocalPlayer) { return; }

        ClientNumber = GameManager.NumberOfClients;
        GameManager.NumberOfClients += 1;
        if(ClientNumber == 0)
        {
            GameManager.Player1.Add(gameObject.transform);
        }
        else if(ClientNumber == 1)
        {
            GameManager.Player2.Add(gameObject.transform);
        }
        

        for (int u = 0; u < startSize; u++)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddSnakePice(ClientNumber, PicePref);
            Debug.Log("Adding");
        }
    }


    public void FixedUpdate()
    {
        if(!isLocalPlayer) { return; }

        GameObject.Find("GameManager").GetComponent<GameManager>().MoovePices(ClientNumber);

        gameObject.transform.Translate(0, Speed * Time.deltaTime, 0);

        gameObject.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * RotationSpeed * -1);
    }
}
