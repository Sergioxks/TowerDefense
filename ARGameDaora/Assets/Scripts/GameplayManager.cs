using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject portalSpawn;
    public GameObject spawnerLocation;


    public void setSpawnerLocation(GameObject spawnerLocationFunc)
    {
        spawnerLocation = spawnerLocationFunc;
    }
    public void spawnPortal(Vector3 distance)
    {
        distance.y += 2.5f;
        if (spawnerLocation == null)
        {
            GameObject portal = Instantiate(portalSpawn, distance, Quaternion.identity);
        }
        else
        {
            GameObject portal = Instantiate(portalSpawn, spawnerLocation.transform.position, Quaternion.identity);
        }
        
    }
}
