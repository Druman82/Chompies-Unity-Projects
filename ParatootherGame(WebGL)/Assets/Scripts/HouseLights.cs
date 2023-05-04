using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLights : MonoBehaviour
{
    public GameObject lights;
    public GameObject lights2;
    public GameObject lights3;
    public GameObject lights4;
    public GameObject lights5;
    public GameObject fireflies;

    void Update()
    {
        if (Settings.night == true)
        {
            lights.gameObject.SetActive(true);
            lights2.gameObject.SetActive(true);
            lights3.gameObject.SetActive(true);
            lights4.gameObject.SetActive(true);
            lights5.gameObject.SetActive(true);
            fireflies.gameObject.SetActive(true);
        }
        else if (Settings.night == false)
        {
            lights.gameObject.SetActive(false);
            lights2.gameObject.SetActive(false);
            lights3.gameObject.SetActive(false);
            lights4.gameObject.SetActive(false);
            lights5.gameObject.SetActive(false);
            fireflies.gameObject.SetActive(false);
        }
    }
}
