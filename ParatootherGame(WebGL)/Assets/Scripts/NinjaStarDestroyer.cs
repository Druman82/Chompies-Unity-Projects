using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Settings.ninjaStarCount >= 4)
        {
            gameObject.SetActive(false);
        }
    }
}
