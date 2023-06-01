using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToEnemy : MonoBehaviour
{
    public Transform Player;
    public PlayerController2 playerController2;

    public Menu menu;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //playerController2.Finish();

            //menu.Dead();
        }
    }
}
