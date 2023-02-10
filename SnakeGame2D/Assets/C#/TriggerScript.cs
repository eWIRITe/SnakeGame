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

    public void FixedUpdate()
    {
        Timer += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Timer >= NotActiveTimeTo) 
        { 
            if (collision.tag == "Bonus")
            {
                Player.GetComponent<SnakeScript>().AddPice();
                Destroy(collision.gameObject);
            }
            else if (collision.tag == "Barier")
            {
                ComDead();
            }
        }
    }

    public void ComDead()
    {
        GameObject.Find("NetworkManeger").GetComponent<NetworkManager>().OnDead();
    }
}

 
