using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TMP_Text waves, enemies;

    private void Start()
    {
        waves.text = "You Survived:" + PlayerPrefs.GetInt("_WavesSurvived") + "\nWaves";
        enemies.text = "You Destroyed:"+PlayerPrefs.GetInt("_ShipsDestroyed")+"\nAliens";
    }
}
