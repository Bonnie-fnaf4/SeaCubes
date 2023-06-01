using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixEnemy2 : MonoBehaviour
{
    public BoxCollider boxCollider;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            boxCollider.isTrigger = true;
        }
    }
}
