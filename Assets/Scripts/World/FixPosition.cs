using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public GraundController[] graundControllers;

    public int[] idGraundControllers;

    public GameObject[] gameObjectsGraundControllers;

    public Vector3[] startTransformGraundControllers, transformGraundControllers;

    public GameObject Player;

    public Vector3 PlayerTransform;

    public Rigidbody[] rigidbodyGraundControllers, setRigidbodyGraundControllers;

    private void Start()
    {
        for (int i = 0; i < startTransformGraundControllers.Length; i++)
        {
            startTransformGraundControllers[i] 
                = new Vector3(
                    gameObjectsGraundControllers[i].transform.position.x,
                gameObjectsGraundControllers[i].transform.position.y,
                gameObjectsGraundControllers[i].transform.position.z);

            setRigidbodyGraundControllers[i] = rigidbodyGraundControllers[i];
        }

        PlayerTransform = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
    }

    private void Update()
    {
        if(Player.transform.position.z >= 100000)
        {
            ResetPosition();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        SetPosition();

        for (int i = 0; i < startTransformGraundControllers.Length; i++)
        {
            graundControllers[i].posStartZ = 110;
            graundControllers[i].posEndZ = -70;
            //graundControllers[i].posStartZStart = 110;
            //graundControllers[i].posEndZStart = -70;
            graundControllers[i].playerSteep = 0;

            gameObjectsGraundControllers[i].transform.position = transformGraundControllers[idGraundControllers[i]];

            //rigidbodyGraundControllers[i].isKinematic = setRigidbodyGraundControllers[idGraundControllers[i]].isKinematic;
            //rigidbodyGraundControllers[i].useGravity = setRigidbodyGraundControllers[idGraundControllers[i]].useGravity;
            //rigidbodyGraundControllers[i].velocity = setRigidbodyGraundControllers[idGraundControllers[i]].velocity;

            rigidbodyGraundControllers[i].isKinematic = true;
            rigidbodyGraundControllers[i].useGravity = false;
            rigidbodyGraundControllers[i].velocity = Vector3.zero;
        }

        Player.transform.position = PlayerTransform;
    }

    public void NumberSet(int id)
    {
        for(int i = 0; i < idGraundControllers.Length; i++)
        {
            idGraundControllers[i]++;
        }

        idGraundControllers[id] = 0;
    }

    public void SetPosition()
    {
        for (int i = 0; i < startTransformGraundControllers.Length; i++)
        {
            transformGraundControllers[i]
                = new Vector3(
                    gameObjectsGraundControllers[i].transform.position.x - (gameObjectsGraundControllers[i].transform.position.x - startTransformGraundControllers[i].x),

                startTransformGraundControllers[i].y,

                gameObjectsGraundControllers[i].transform.position.z - (gameObjectsGraundControllers[i].transform.position.z - startTransformGraundControllers[i].z));
        }
    }
}
