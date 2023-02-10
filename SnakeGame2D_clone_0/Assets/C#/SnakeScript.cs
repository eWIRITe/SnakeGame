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

    public void Start()
    {
        if (!isOwned) { return; }

        //create snake body
        for (int u = 0; u < startSize; u++)
        {
            AddPice();
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
        GameObject.Find("GameManager").GetComponent<GameManager>().AddSnakePice(PicePref, gameObject);
    }
}
