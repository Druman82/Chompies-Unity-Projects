using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celing : MonoBehaviour
{
    [SerializeField] private Transform target1 = null;
    [SerializeField] private Transform target2 = null;
    [SerializeField] private Transform target3 = null;
    [SerializeField] private Transform target4 = null;
    [SerializeField] private Transform target5 = null;
    private Transform target;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.target == 1)
        {
            target = target1;
        }
        else if (Settings.target == 2)
        {
            target = target2;
        }
        else if (Settings.target == 3)
        {
            target = target3;
        }
        else if (Settings.target == 4)
        {
            target = target4;
        }
        else if (Settings.target == 5)
        {
            target = target5;
        }
        offset = transform.position - target.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, 5, target.position.z) + offset, Time.deltaTime);
    }
}
