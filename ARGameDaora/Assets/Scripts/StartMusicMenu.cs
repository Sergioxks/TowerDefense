using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicMenu : MonoBehaviour
{
    public AudioSource menuMusic;
    // Start is called before the first frame update
    void Start()
    {
        if (!menuMusic.isPlaying)
        {
            menuMusic.Play();
        }
        
    }

}
