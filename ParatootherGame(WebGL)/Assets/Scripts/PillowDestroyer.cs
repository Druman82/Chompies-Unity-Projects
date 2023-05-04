using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Settings.pillowCount >= 5)
        {
            gameObject.SetActive(false);
        }
    }
}
