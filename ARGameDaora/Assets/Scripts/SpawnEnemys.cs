using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnEnemys : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject enemy;
    public float fireRate = 30;
    private float nextFire = 0;



    private void Start()
    {
        GameObject obj = Instantiate(enemy, spawnLocation.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject obj = Instantiate(enemy, spawnLocation.transform.position, Quaternion.identity);
        }
    }
}
