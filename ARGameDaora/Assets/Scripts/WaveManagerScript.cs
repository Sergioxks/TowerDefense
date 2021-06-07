using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveManagerScript : MonoBehaviour
{
    private const float ENEMY_TIMER_NEXT_MAX = 6f;
    private const float WAVE_TIMER_NEXT_MAX = 10f;

    public GameObject m_ObjectSpawner, city;
    public GameObject[] m_SpawnLocations;

    public List<GameObject> l_ActivePortals = new List<GameObject>();

    public SpawnEnemies m_SpawnEnemiesScript;

    public int killCount, waveLeft, waveCount, portalCount;
    public float enemyTimerNext, waveTimerNext;

    public TMP_Text waveCountdown;

    //debugging
    public Text waveCountText, waveLeftText, portalCountText, waveTimerText, enemyTimerText;

    void Awake()
    {
        waveCountText = GameObject.Find("WaveCount").GetComponent<Text>();
        waveLeftText = GameObject.Find("WaveLeft").GetComponent<Text>();
        portalCountText = GameObject.Find("PortalCount").GetComponent<Text>();
        waveTimerText = GameObject.Find("WaveTimerNext").GetComponent<Text>();
        enemyTimerText = GameObject.Find("EnemyTimerNext").GetComponent<Text>();
        waveCountdown = GameObject.Find("WaveCountdown").GetComponent<TMP_Text>();

        waveCount = 1;
        killCount = 0;
        portalCount = 1;
        waveLeft = 5;
        waveTimerNext = WAVE_TIMER_NEXT_MAX;
        enemyTimerNext = 0f;

        //waveCountdown.faceColor = new Color32(255, 255, 255, 0);
        waveCountdown.enabled = false;

        city = GameObject.FindGameObjectWithTag("City");
        m_SpawnLocations = GameObject.FindGameObjectsWithTag("PortalSpawnLocation");
        m_SpawnEnemiesScript = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<SpawnEnemies>();
    }

    void Start()
    {
        l_ActivePortals.Add(m_ObjectSpawner as GameObject);
    }

    void Update()
    {
        //debugging
        waveCountText.text = "Wave: " + waveCount.ToString();
        waveLeftText.text = "EnemiesLeft: " +  waveLeft.ToString();
        portalCountText.text = "Portals: " +  portalCount.ToString();
        waveTimerText.text = "NextWave: " + waveTimerNext.ToString();
        enemyTimerText.text = "NextEnemy: " + enemyTimerNext.ToString();
        //gaming

        if (waveTimerNext > 0)
        {
            waveTimerNext -= Time.deltaTime;

            if(waveTimerNext < 6 && waveTimerNext > 1)
            {
                waveCountdown.enabled = true;
                waveCountdown.text = Mathf.Floor(waveTimerNext).ToString();
            }
            else if(waveTimerNext < 1)
            {
                waveCountdown.text = "Begin!";
            }
            
        }
        else
        {
            waveCountdown.enabled = false;

            if (waveCount % 5 == 0 && portalCount < (Mathf.Floor(waveCount/5) + 1) && portalCount < 10)
            {
                SpawnPortal();
            }

            if(enemyTimerNext > 0)
            {
                enemyTimerNext -= Time.deltaTime;
            }
            else
            {
                if(waveLeft > 0)
                {
                    foreach (GameObject portal in l_ActivePortals)
                    {
                        if(waveLeft > 0)
                        {
                            m_SpawnEnemiesScript.SpawnEnemy(portal);
                            waveLeft--;
                        }
                       
                    }
                    enemyTimerNext = ENEMY_TIMER_NEXT_MAX * portalCount;
                }
                else
                {
                    waveTimerNext = WAVE_TIMER_NEXT_MAX;
                    enemyTimerNext = 0;
                    waveCount++;
                    waveLeft = (2 * waveCount) + 3;
                }
            }
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
        obj.transform.LookAt(city.transform.position);
        m_SpawnLocations[chooseSpawn].GetComponent<SpawnLocationScript>().locationAvailable = false;

        l_ActivePortals.Add(obj as GameObject);
        portalCount++;
    }
}
