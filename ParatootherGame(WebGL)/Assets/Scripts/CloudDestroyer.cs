using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestroyer : MonoBehaviour
{
    public GameObject cloudDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        cloudDestructionPoint = GameObject.Find("CloudDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < cloudDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
