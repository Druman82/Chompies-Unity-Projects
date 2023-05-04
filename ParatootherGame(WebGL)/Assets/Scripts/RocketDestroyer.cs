using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestroyer : MonoBehaviour
{
    void Update()
    {
        if(Settings.rocketCount >= 5)
        {
           gameObject.SetActive(false);
        }
    }
}
