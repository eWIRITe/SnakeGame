using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : NetworkBehaviour
{
    public GameObject Player;

    public float NotActiveTimeTo;
    private float Timer;

    private bool Dead = false;

    public void FixedUpdate()
    {
        //Timer
        Timer += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Timer >= NotActiveTimeTo)
        {
            //if it is bonus
            if (collision.tag == "Bonus")
            {
                Player.GetComponent<SnakeScript>().AddPice();
                Destroy(collision.gameObject);
            }

            //if it is barier
            else if (collision.tag == "Barier" && !Dead)
            {
                GameObject.Find("NetworkManeger").GetComponent<NetworkManager>().OnDead();
                Dead = true;
            }
        }
    }
}

 
