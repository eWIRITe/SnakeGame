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


    public void Start()
    {
        if (!isLocalPlayer) { return; }

        for (int u = 0; u < startSize; u++)
        {
            AddPice();
        }
    }


    public void FixedUpdate()
    {
        if(!isLocalPlayer) { return; }

        

        for(int i = 0; i < Pices.Count; i++)
        {
            Transform thisObj = Pices[i];

            if (i == 0)
            {
                thisObj.transform.Translate(0, Speed * Time.deltaTime, 0);

                thisObj.Rotate(0, 0, Input.GetAxis("Horizontal") * RotationSpeed * -1);
            }
            else
            {

                Transform lastObj = Pices[i-1];

                Vector2 direction = lastObj.transform.position - thisObj.transform.position;

                thisObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

                float Dis = Vector2.Distance(lastObj.position, thisObj.position);

                if (MaxDistance < Dis) { thisObj.transform.Translate(0, Dis - MaxDistance, 0); }
            }

        }
        
    }

    [Command]
    public void AddPice()
    {
        var newObj =  Instantiate(PicePref);

        Pices.Add(newObj.transform);

        NetworkServer.Spawn(newObj);
    }
}
