using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenConfigMenu : MonoBehaviour
{

    public GameObject canvasPause;
    public void PauseGame()
    {
        Time.timeScale = 0.1f;
        canvasPause.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        canvasPause.SetActive(false);
    }
}
