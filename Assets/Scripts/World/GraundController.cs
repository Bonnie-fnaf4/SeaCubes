using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class GraundController : MonoBehaviour
{
    public float posStartZ, posEndZ, posStartZStart, posEndZStart, speed, playerSteep;
    [SerializeField] Rigidbody rigidbody;
    public SpawnObjects spawnObjects;

    bool fall = false;

    public Transform player;

    public bool end;

    public int object1, object2;

    public FixPosition fixPosition;
    public int id;

    public bool isOptimize = false;

    float maxVelositi = 9.8038f;

    private void Start()
    {
        posEndZ = posEndZStart + playerSteep;
        rigidbody = GetComponent<Rigidbody>();
        SetSpawnObject(0);
        //end = false;
    }

    private void FixedUpdate()
    {
        //if (maxVelositi < rigidbody.velocity.y) maxVelositi = rigidbody.velocity.y;

        if(rigidbody.velocity.y > maxVelositi)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, maxVelositi, rigidbody.velocity.z);
        }

        if(player.position.z > playerSteep)
        {
            playerSteep += 10;
            posEndZ = posEndZStart + playerSteep;
            posStartZ = posStartZStart + playerSteep;
        }

        if (transform.position.z <= posEndZ + 25)
        {
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            fall = true;
            //spawnObjects.OffBoxCollider();
            spawnObjects.OffColisicon();
            //rigidbody.AddForce(0, 10, 0);
        }

        if (transform.position.z <= posEndZ)
        {
            fall = false;

            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            //rigidbody.isKinematic = false;
            //rigidbody.useGravity = true;
            transform.rotation = Quaternion.Euler(0,0,0);
            transform.position = new Vector3(0, 3.1f, posStartZ);

            spawnObjects.OffColisicon();

            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;


            rigidbody.AddForce(0, 500, 0);

            SpawnObjectEvent();

            spawnObjects.OffColisicon();
        }

        if (transform.position.y < 3.1f && !fall)
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;

            spawnObjects.OnColisicon();

            transform.position = new Vector3(0, 3.1f, transform.position.z);
        }
    }

    public void SpawnObjectEvent()
    {
        fixPosition.NumberSet(id);

        if (end)
        {
            spawnObjects.RefrashPanel();
            spawnObjects.RefrashSpawnObject();
            return;
        }

        int random = Random.RandomRange(1, 100);

        spawnObjects.RefrashPanel();
        spawnObjects.RefrashSpawnObject();

        if(random <= object1)
        {
            int random2 = Random.RandomRange(1, 100);
            if(object1 == 25 && object2 == 100)
            {
                if (random2 <= 5)
                {
                    spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 0);
                    return;
                }
                if (random2 <= 50)
                {
                    spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 1);
                    return;
                }
                if (random2 <= 95)
                {
                    spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 2);
                    return;
                }
            }
            else
            {
                if (random2 <= 5)
                {
                    spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 2);
                    return;
                }
                if (random2 <= 50)
                {
                    spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 1);
                    return;
                }
                if (random2 <= 95)
                {
                    spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 0);
                    return;
                }
            }
        }
        else
        {
            if (random <= object2)
            {
                int random2 = Random.RandomRange(1, 100);
                if (random2 <= 25)
                {
                    int random3 = Random.RandomRange(1, 100);
                    if(random3 >= 50) spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 4);
                    else spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 6);
                    return;
                }
                if (random2 <= 50)
                {
                    int random3 = Random.RandomRange(1, 100);
                    if (random3 >= 50) spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 3);
                    else spawnObjects.OnSpawn(Random.RandomRange(0, spawnObjects.panel.Length), 5);
                    return;
                }
                if (random2 <= 100)
                {
                    spawnObjects.OffPanel(Random.RandomRange(0, spawnObjects.panel.Length));
                    return;
                }
                //spawnObjects.OffPanel(Random.RandomRange(0, spawnObjects.panel.Length));
            }
        }
    }

    public void SetSpawnObject(int id)
    {
        if(id == 0)
        {
            object1 = 50;
            object2 = 100;
        }

        if (id == 1)
        {
            object1 = 50;
            object2 = 100;
        }

        if (id == 2)
        {
            object1 = 85;
            object2 = 0;
        }

        if (id == 3)
        {
            object1 = 50;
            object2 = 100;
        }

        if (isOptimize)
        {
            object1 = object1 / 2;
            object2 = object2 / 2;
        }
    }
}
