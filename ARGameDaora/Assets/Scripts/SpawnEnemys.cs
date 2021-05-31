using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnEnemys : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject enemy;

    public float timeBetweenWaves = 40f;


    private void Start()
    {
        GameObject obj = Instantiate(enemy, spawnLocation.transform.position, Quaternion.identity);
    }
}
