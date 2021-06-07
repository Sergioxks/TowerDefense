using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingShoot : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject pos, laser;
    public float sensibilidade = 2.0f; //Controla a sensibilidade do mouse
                                       // Update is called once per frame
    private float mouseX = 0.0f, mouseY = 0.0f; //Variáveis que controla a rotação do mouse

    public bool travarMouse = true; //Controla se o cursor do mouse é exibido

    void Start()
    {
        if (!travarMouse)
        {
            return;
        }

        Cursor.visible = false; //Oculta o cursor do mouse
        Cursor.lockState = CursorLockMode.Locked; //Trava o cursor do centro
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Shoot();
        }

        mouseX += Input.GetAxis("Mouse X") * sensibilidade; // Incrementa o valor do eixo X e multiplica pela sensibilidade
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade; // Incrementa o valor do eixo Y e multiplica pela sensibilidade. (Obs. usamos o - para inverter os valores)

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    public void Shoot()
    {
        GameObject m_MuzzleInstance = Instantiate(laser, pos.transform.position, pos.transform.rotation);
        Destroy(m_MuzzleInstance, 1f);
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("HIT");
            }
        }
    }
}
