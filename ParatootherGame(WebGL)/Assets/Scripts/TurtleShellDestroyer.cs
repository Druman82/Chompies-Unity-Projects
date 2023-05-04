using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShellDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Settings.sewerPipe == true)
        {
            gameObject.SetActive(false);
        }
    }
}
