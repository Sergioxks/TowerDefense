using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    private const float DAMAGE_FADE_TIMER_MAX = 1f;

    [Header("Status")]
    public float m_MaxHealth = 100.0f;
    public float m_CurrentHealth = 100.0f;

    [Header("UI")]
    public Image m_FillBar;
    public Image m_damagedBar;
    private Color m_damagedColor;

    private float m_damageFadeTimer;

    private void awake()
    {
        m_FillBar = GameObject.Find("FillBar").GetComponent<Image>();
        m_damagedBar = GameObject.Find("FillBarFade").GetComponent<Image>();

        m_damagedColor = m_damagedBar.color;
        m_damagedColor.a = 0f;
        m_damagedBar.color = m_damagedColor;
    }

    public void UpdateUI()
    {
        float fillAmount = m_CurrentHealth / m_MaxHealth;
        m_FillBar.fillAmount = fillAmount;
    }

    public void TakeDamage(float hit)
    {
        if(m_damagedColor.a <= 0)
        {
            //Fading bar is invisible
            m_damagedBar.fillAmount = m_FillBar.fillAmount;
        }
        m_damagedColor.a = 1;
        m_damagedBar.color = m_damagedColor;
        m_damageFadeTimer = DAMAGE_FADE_TIMER_MAX;

        m_CurrentHealth -= hit;
        m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0.0f, m_MaxHealth);
        UpdateUI();
    }


    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if(m_damagedColor.a > 0)
        {
            m_damageFadeTimer -= Time.deltaTime;
            if(m_damageFadeTimer < 0)
            {
                float fadeAmount = 5f;
                m_damagedColor.a -= fadeAmount * Time.deltaTime;
                m_damagedBar.color = m_damagedColor;
            }
        }
    }
}
