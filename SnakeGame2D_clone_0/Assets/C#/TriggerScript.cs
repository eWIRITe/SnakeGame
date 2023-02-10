using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeadScreen;

    public void Start()
    {
        DeadScreen = GameObject.Find("Dead");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bonus")
        {
            Player.GetComponent<SnakeScript>().AddPice();
            Destroy(collision.gameObject);
        }
    }
}

 
