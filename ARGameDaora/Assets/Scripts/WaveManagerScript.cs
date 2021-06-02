using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    private const float NEXT_WAVE_TIMER_MAX = 10f;

    public GameObject m_ObjectSpawner;
    public GameObject[] m_SpawnLocations;

    public int killCount, waveLeft, waveCount, portalCount;

    void Awake()
    {
        waveCount = 1;
        killCount = 0;
        portalCount = 0;

        m_SpawnLocations = GameObject.FindGameObjectsWithTag("PortalSpawnLocation");
    }

    void Start()
    {

    }

    void Update()
    {

        if(portalCount < 10)
        {
            SpawnPortal();
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

    public void SpawnPortal()
    {
        var chooseSpawn = (Random.Range(0, m_SpawnLocations.Length - 1));

        while(!m_SpawnLocations[chooseSpawn].GetComponent<SpawnLocationScript>().locationAvailable)
        {
            chooseSpawn = (Random.Range(0, m_SpawnLocations.Length));
        }

        GameObject obj = Instantiate(m_ObjectSpawner, m_SpawnLocations[chooseSpawn].transform.position, Quaternion.identity);
        m_SpawnLocations[chooseSpawn].GetComponent<SpawnLocationScript>().locationAvailable = false;

        portalCount++;
    }
}
