using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorMenu : MonoBehaviour
{
    public Transform cloudGenerationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float distanceOf;
    public float distanceAt;

    private int cloudSelector;
    private float[] cloudWidths;
    public ObjectPooler[] theCloudPools;
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    void Start()
    {
        cloudWidths = new float[theCloudPools.Length];

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    void Update()
    {
        if (transform.position.z < cloudGenerationPoint.position.z)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            distanceOf = Random.Range(-400, 500);

            distanceAt = Random.Range(50, 150);

            cloudSelector = Random.Range(0, theCloudPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            transform.position = new Vector3(distanceOf, distanceAt, transform.position.z + distanceBetween);

            GameObject newCloud = theCloudPools[cloudSelector].GetPooledObject();

            newCloud.transform.position = transform.position;
            newCloud.SetActive(true);
        }
    }
}
