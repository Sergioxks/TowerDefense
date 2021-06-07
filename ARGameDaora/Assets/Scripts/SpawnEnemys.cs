using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnEnemys : MonoBehaviour
{
    public GameObject enemy;
    public WaveManagerScript m_WaveManagerScript;

    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        m_WaveManagerScript = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManagerScript>();
    }

    public void SpawnEnemy(GameObject portal)
    {
        GameObject obj = (GameObject)Instantiate(enemy, portal.transform.position, Quaternion.identity, transform);
        obj.transform.Rotate(new Vector3(270f, 90f, 0f));
    }
}
