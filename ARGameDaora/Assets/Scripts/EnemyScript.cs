using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    public Image m_FillBar;
    public float MoveSpeed = 0.2f;
    int MaxDist = 0;
    int MinDist = 0;
    public bool boss;

    public float maxLife = 40f;
    private float currentLife = 40f;

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
            if (!boss)
            {
                transform.Rotate(new Vector3(270f, -90f, 0f), Space.Self);
            }
            if (boss)
            {
                transform.Rotate(new Vector3(131f, 360f, 180f), Space.Self);
            }


        }

    }

    public void TakeDamage(float amount)
    {

        Debug.Log("Hit");
        currentLife -= amount;
        currentLife = Mathf.Clamp(currentLife, 0.0f, maxLife);
        UpdateUI();
        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateUI()
    {
        float fillAmount = currentLife / maxLife;
        m_FillBar.fillAmount = fillAmount;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "City")
        {
            if (boss)
            {
                m_HealthBar.TakeDamage(20f);
            }
            else
            {
                m_HealthBar.TakeDamage(10f);
            }
           

            Debug.Log("This is your fault");
            Destroy(gameObject);
        }
    }
}
