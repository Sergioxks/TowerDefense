using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed = 0.1f;
    int MaxDist = 0;
    int MinDist = 0;



    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("City");
    }

    void Update()
    {
        transform.LookAt(Player.transform);

        if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
    }

}
