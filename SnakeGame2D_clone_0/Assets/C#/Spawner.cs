using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    public GameObject BonusPref;

    public Transform pos1;
    public Transform pos2;

    public float TimeTo;
    public float Timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Timer >= TimeTo)
        {
            Spawn();
            Timer = 0;
        }
        else
        {
            Timer += Time.deltaTime;
        }
    }

    [Command]
    public void Spawn()
    {
        Instantiate(BonusPref, new Vector3(Random.Range(pos1.position.x, pos2.position.x), Random.Range(pos1.position.y, pos2.position.y), pos1.position.z), Quaternion.identity);
    }
}
