using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    //placeholder variable. will deal with this shit later
    public GameObject spawnerFirst;
    public WaveManagerScript m_WaveManagerScript;

    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        spawnerFirst = GameObject.FindGameObjectWithTag("Spawner");
        m_WaveManagerScript = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManagerScript>();
    }

    public void SpawnEnemy(GameObject portal)
    {
        GameObject obj = Instantiate(enemy, portal.transform.position, Quaternion.identity);
        GameObject obj2 = Instantiate(enemy, spawnerFirst.transform.position, Quaternion.identity);

    }
}
