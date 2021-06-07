using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingShoot : MonoBehaviour
{
    public GameObject pos, laser;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject m_MuzzleInstance = Instantiate(laser, pos.transform.position, pos.transform.rotation);
            Destroy(m_MuzzleInstance, 1f);
        }

    }
}
