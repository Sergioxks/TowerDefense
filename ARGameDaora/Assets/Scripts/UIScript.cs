using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public Text hpText;
    public int hpValue;

    void Start()
    {
        hpValue = 3;
    }
    // Update is called once per frame
    void Update()
    {
        hpText.text = "Life: " + hpValue;
    }
}
