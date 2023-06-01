using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanController : MonoBehaviour
{
    public float posStartZ, posEndZ, posStartZStart, posEndZStart, speed, playerSteep, yPosToSpawn, forseToSpawn; 
    [SerializeField] Rigidbody rigidbody;

    bool fall = false;

    public Transform player;
    public int id;

    private void Start()
    {
        posEndZ = posEndZStart + playerSteep;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player.position.z > playerSteep)
        {
            playerSteep += 100;
            posEndZ = posEndZStart + playerSteep;
            posStartZ = posStartZStart + playerSteep;
        }

        //if (transform.position.z <= posEndZ + 200)
        //{
        //    rigidbody.isKinematic = false;
        //    rigidbody.useGravity = true;
        //    fall = true;
        //    //rigidbody.AddForce(0, -10, 0);
        //}

        if (transform.position.z <= posEndZ)
        {
            fall = false;

            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            //rigidbody.isKinematic = false;
            //rigidbody.useGravity = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(0, yPosToSpawn, posStartZ);

            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;

            rigidbody.AddForce(0, forseToSpawn, 0);
        }

        if (transform.position.y > 0f && !fall)
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            transform.position = new Vector3(0, 0f, transform.position.z);
        }
    }
}
