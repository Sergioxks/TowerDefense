using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject arCamera,impactEffect,pos;
    public GameObject muzzleFlash;
    public AudioSource shootSound;
    public float range, damageAmount=20,impactForce=5,fireRate=2;
    private float nextFire = 0;


    private void Start()
    {
        shootSound = gameObject.GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (Time.time >= nextFire)
        {
            shootSound.Play();
            GameObject m_MuzzleInstance = Instantiate(muzzleFlash, pos.transform.position, Quaternion.identity);
            nextFire = Time.time + 1f / fireRate;
            RaycastHit hit;
            Handheld.Vibrate();
            if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit, range))
            {
                if (hit.transform.tag == "Enemy")
                {
                    EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
                    enemy.TakeDamage(damageAmount);
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                    GameObject m_ImpactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(m_ImpactObj, 1f);
                }
            }
            Destroy(m_MuzzleInstance, 0.5f);
        }

    }
}
