using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TutorialScript : MonoBehaviour
{
    public string[] texts;
    public Sprite[] tutorialImages;
    private int currentText;
    public TMP_Text tutorialText;
    public Image tutorialImage;
    public void NextText()
    {
        if (currentText== texts.Length-1)
        {
            currentText = texts.Length-1;
        }
        else
        {
            currentText++;
        }
        tutorialText.text=texts[currentText];
        tutorialImage.sprite = tutorialImages[currentText];
    }
    public void PreviousText()
    {
        if (currentText == 0)
        {
            currentText = 0;
        }
        else
        {
            currentText--;
        }

        tutorialText.text = texts[currentText];
        tutorialImage.sprite = tutorialImages[currentText];
    }
}
