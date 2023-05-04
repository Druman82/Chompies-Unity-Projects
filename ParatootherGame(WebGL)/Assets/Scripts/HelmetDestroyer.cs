using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Settings.spaceship == true)
        {
            gameObject.SetActive(false);
        }
    }
}
