using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    private const float NEXT_WAVE_TIMER_MAX = 10f;

    public GameObject m_ObjectSpawner;
    public GameObject[] m_SpawnLocations;

    public List<GameObject> l_ActivePortals = new List<GameObject>();

    public SpawnEnemies m_SpawnEnemiesScript;

    public int killCount, waveLeft, waveCount, portalCount;
    public float enemyTimerNext = 5f;

    void Awake()
    {
        waveCount = 1;
        killCount = 0;
        portalCount = 0;
        waveLeft = 99;

        m_SpawnLocations = GameObject.FindGameObjectsWithTag("PortalSpawnLocation");
        m_ObjectSpawner = GameObject.FindGameObjectWithTag("Spawner");
        m_SpawnEnemiesScript = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<SpawnEnemies>();
    }

    void Start()
    {
        l_ActivePortals.Add(m_ObjectSpawner as GameObject);
    }

    void Update()
    {
        if(enemyTimerNext > 0)
        {
            enemyTimerNext -= Time.deltaTime;
        }
        else
        {
            if (portalCount < 3)
            {
                SpawnPortal();
            }

            if (waveLeft > 0)
            {
                foreach (GameObject portal in l_ActivePortals)
                {
                    m_SpawnEnemiesScript.SpawnEnemy(portal);
                    waveLeft--;
                }
            }

            enemyTimerNext = 5f;
        }
        
    }

    //Debugging the spawn areas
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);

        foreach (GameObject portal in m_SpawnLocations)
        {
            Gizmos.DrawCube(portal.transform.position, new Vector3 (0.2f,0.2f,0.2f));
        };
    }

    void SpawnPortal()
    {
        var chooseSpawn = (Random.Range(0, m_SpawnLocations.Length - 1));

        Debug.Log("gamer");

        while(!m_SpawnLocations[chooseSpawn].GetComponent<SpawnLocationScript>().locationAvailable)
        {
            chooseSpawn = (Random.Range(0, m_SpawnLocations.Length));
        }

        GameObject obj = Instantiate(m_ObjectSpawner, m_SpawnLocations[chooseSpawn].transform.position, Quaternion.identity);
        m_SpawnLocations[chooseSpawn].GetComponent<SpawnLocationScript>().locationAvailable = false;

        l_ActivePortals.Add(obj as GameObject);
        portalCount++;
    }
}
