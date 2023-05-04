using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource crystalCaveBGMusic;

    [SerializeField] public Transform musicCheckmarkOn;
    [SerializeField] public Transform musicCheckmarkOff;
    [SerializeField] public Transform fXCheckmarkOn;
    [SerializeField] public Transform fXCheckmarkOff;
    
    void Start()
    {
        if (Settings.musicBool == false)
        {
            crystalCaveBGMusic.Stop();
        }
        else if (Settings.musicBool == true)
        {
            crystalCaveBGMusic.Play();
        } 
    }
    void Update()
    {
        //Music Toggle
        if (Settings.musicBool == false)
        {
            musicCheckmarkOn.gameObject.SetActive(false);
            musicCheckmarkOff.gameObject.SetActive(true);
        }
        else if (Settings.musicBool == true)
        {
            musicCheckmarkOn.gameObject.SetActive(true);
            musicCheckmarkOff.gameObject.SetActive(false);
        }
        
        //Sound FX Toggle
        if (Settings.soundFXBool == false)
        {
            fXCheckmarkOn.gameObject.SetActive(false);
            fXCheckmarkOff.gameObject.SetActive(true);
        }
        else if (Settings.soundFXBool == true)
        {
            fXCheckmarkOn.gameObject.SetActive(true);
            fXCheckmarkOff.gameObject.SetActive(false);
        }
    }
}
