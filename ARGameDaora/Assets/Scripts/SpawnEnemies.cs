using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemy;
    public WaveManagerScript m_WaveManagerScript;

    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        m_WaveManagerScript = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManagerScript>();
    }

    public void SpawnEnemy(GameObject portal, int type)
    {
        GameObject obj = (GameObject)Instantiate(enemy[type], portal.transform.position, Quaternion.identity, transform);
        obj.transform.Rotate(new Vector3(270f, 90f, 0f));
    }
}
