using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationScript : MonoBehaviour
{
    public bool locationAvailable;

    void Awake()
    {
        locationAvailable = true;
    }
}
