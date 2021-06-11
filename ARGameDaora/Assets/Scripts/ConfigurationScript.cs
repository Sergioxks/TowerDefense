using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ConfigurationScript : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetSfxLevel(float sfxLvl)
    {
        PlayerPrefs.SetFloat("_VolumeSFX", sfxLvl);
        masterMixer.SetFloat("VolumeSFX", PlayerPrefs.GetFloat("_VolumeSFX"));
        
    }
    public void SetMusicLevel(float musicLvl)
    {
        PlayerPrefs.SetFloat("_VolumeMusic", musicLvl);
        masterMixer.SetFloat("VolumeMusic", PlayerPrefs.GetFloat("_VolumeMusic"));
    }

    public void SetVibration(bool vibration)
    {
        PlayerPrefs.SetInt("_Vibration", vibration ? 1 : 0);
        if ((PlayerPrefs.GetInt("_Vibration") == 1 ? true : false) == true)
        {
            Debug.Log("Vibrou");
        }
    }
}
