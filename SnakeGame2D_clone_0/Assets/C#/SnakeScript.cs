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

        //create snake start body
        for (int u = 0; u < startSize; u++)
        {
            AddPice();
        }
    }


    public void FixedUpdate()
    {
        if (!isOwned) { return; }

        float _speed = Speed;

        if(Input.GetKey(KeyCode.W)) 
        {
            _speed *= 2;
        }

        //moove head
        gameObject.transform.Translate(0, _speed * Time.deltaTime, 0);
        //rotate head
        gameObject.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * RotationSpeed * -1);
    }

    [Command]
    public void AddPice()
    {
        //call function on server from client
        GameObject.Find("GameManager").GetComponent<GameManager>().AddSnakePice(PicePref, gameObject);
    }
}
