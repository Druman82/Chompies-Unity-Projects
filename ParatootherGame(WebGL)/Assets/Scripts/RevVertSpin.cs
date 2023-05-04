using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevVertSpin : MonoBehaviour
{
    float speed = -50.0f;

    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
