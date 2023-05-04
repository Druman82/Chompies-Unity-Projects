using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject lights;
    public GameObject lights2;

    void Update()
    {
        if (Settings.night == true || Settings.city == true)
        {
            lights.gameObject.SetActive(true);
            lights2.gameObject.SetActive(true);
        }
        else if (Settings.night == false)
        {
            lights.gameObject.SetActive(false);
            lights2.gameObject.SetActive(false);
        }
    }
}
