﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class RandomTextUI : MonoBehaviour
{
    [Header("UI")]
    public TextAsset m_TextFile;
    private TMP_Text m_TextUI;

    [Header("Debug")]
    public Phrase m_Phrase;

    private void Awake()
    {
        m_TextUI = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        string json = m_TextFile.text;
        m_Phrase = JsonUtility.FromJson<Phrase>(json);
        int index = Random.Range(0, m_Phrase.Length);
        m_TextUI.text = m_Phrase[index];
        Canvas.ForceUpdateCanvases();
        StartCoroutine("WaitAndPrint");

    }
    IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            string json = m_TextFile.text;
            m_Phrase = JsonUtility.FromJson<Phrase>(json);
            int index = Random.Range(0, m_Phrase.Length);
            m_TextUI.text = m_Phrase[index];
            Canvas.ForceUpdateCanvases();

        }

    }
}

[System.Serializable]
public class Phrase
{
    public string[] phrases;

    public string this[int index]
    {
        get => phrases[index];
        set => phrases[index] = value;
    }

    public int Length => phrases == null ? 0 : phrases.Length;
}