using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayerController2 playerController2;
    public BoxCollider myColider;
    public MeshRenderer meshRenderer;
    public bool isDead = false;

    public Color blackColor, whiteColor, colorPlayer;

    private void Start()
    {
        myColider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if(transform.position.y <= 0)
        {
            if (playerController2 == null)
            {
                Destroy(gameObject);
            }
            else
            {
                playerController2.RemoveCube(myColider, this);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DownPanel" || other.tag == "Enemy")
        {
            if (playerController2 == null)
            {
                Destroy(gameObject);
            }
            else
            {
                BlackCube();
                playerController2.RemoveCube(myColider, this);
                //Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "StartPanel" && isDead)
        {
            BlackCube();
        }
    }

    public void BlackCube()
    {
        if (!(meshRenderer == null)) meshRenderer.material.color = blackColor;
    }
    public void WhiteCube()
    {
        if (!(meshRenderer == null)) meshRenderer.material.color = whiteColor;
    }

    public void PlayerCube()
    {
        meshRenderer.material.color = colorPlayer;
    }
}
