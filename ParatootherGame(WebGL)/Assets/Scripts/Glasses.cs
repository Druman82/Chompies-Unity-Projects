using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour
{
    [SerializeField] private Transform glasses;

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.threeD == true)
        {
            glasses.gameObject.SetActive(false);
        }
        else
        {
            glasses.gameObject.SetActive(true);
        }
    }
}
