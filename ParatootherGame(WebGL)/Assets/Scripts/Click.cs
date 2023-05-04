using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public AudioSource click;
    public AudioSource hover;

    public void Clicking()
    {
        if (Settings.soundFXBool == true)
        {
            click.Play();
        }
    }

    public void Hovering()
    {
        if (Settings.soundFXBool == true)
        {
            hover.Play();
        }
    }
}
