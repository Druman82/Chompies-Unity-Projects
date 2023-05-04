using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Settings.batteryCount >= 4)
        {
            gameObject.SetActive(false);
        }
    }
}
