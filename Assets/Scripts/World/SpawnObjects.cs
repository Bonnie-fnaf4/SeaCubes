using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] panel;
    [SerializeField] GameObject[] spawnObject;
    public Transform[] spawnPoint;

    public GameObject SpawnGameObject;
    public BoxCollider SpawnGameObjectColider;

    public void OnSpawn(int idSpawnPoint, int idObject)
    {
        SpawnGameObject = Instantiate(spawnObject[idObject], spawnPoint[idSpawnPoint]);
        if (!(SpawnGameObject.GetComponent<BoxCollider>() == null)) SpawnGameObjectColider = SpawnGameObject.GetComponent<BoxCollider>();
        if (!(SpawnGameObject.GetComponent<BoxCollider>() == null)) if (SpawnGameObjectColider.isTrigger == true) SpawnGameObjectColider = null;
        Destroy(SpawnGameObject, 10);
        //Instantiate(spawnObject, spawnPoint[1]);
        //Instantiate(spawnObject, spawnPoint[2]);
    }

    public void OffPanel(int idPanel)
    {
        panel[idPanel].SetActive(false);
    }

    public void RefrashPanel()
    {
        for(int i = 0; i < panel.Length; i++)
        {
            panel[i].SetActive(true);
        }
    }
    public void RefrashSpawnObject()
    {
        if (!(SpawnGameObject == null))
        {
            Destroy(SpawnGameObject);
        }
    }
    public void OffBoxCollider()
    {
        if(!(SpawnGameObjectColider == null)) Destroy(SpawnGameObjectColider);
    }

    public void OffColisicon()
    {
        if (!(SpawnGameObjectColider == null)) SpawnGameObjectColider.isTrigger = true;
    }

    public void OnColisicon()
    {
        if (!(SpawnGameObjectColider == null)) SpawnGameObjectColider.isTrigger = false;
    }
}
