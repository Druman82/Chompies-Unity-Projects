using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownCoinDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Settings.crownCoin >= 1)
        {
            gameObject.SetActive(false);
        }
    }
}
