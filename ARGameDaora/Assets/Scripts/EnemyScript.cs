using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    int MoveSpeed = 1;
    int MaxDist = 0;
    int MinDist = 0;

    private UIScript m_UIElement;
    private HealthBarManager m_HealthBar;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("City");
        m_UIElement = GameObject.FindWithTag("UI").GetComponent<UIScript>();
        m_HealthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBarManager>();
    }

    void Update()
    {
        transform.LookAt(Player.transform);

        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "City")
        {
            m_HealthBar.TakeDamage(10f);

            Debug.Log("This is your fault");
            Destroy(gameObject);
        }
    }
}
