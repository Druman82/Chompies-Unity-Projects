using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogGenerator : MonoBehaviour
{
    //public GameObject thePlatform;
    public Transform cloudGenerationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float distanceOf;
    public float distanceAt;

    //public GameObject[] thePlatforms;
    private int cloudSelector;
    private float[] cloudWidths;
    public ObjectPooler[] theCloudPools;
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    // Start is called before the first frame update
    void Start()
    {
        cloudWidths = new float[theCloudPools.Length];

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < cloudGenerationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            distanceOf = Random.Range(-5, -5);

            distanceAt = Random.Range(2, 6);

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
            transform.position = new Vector3(transform.position.x + distanceBetween, distanceAt, distanceOf);

            GameObject newCloud = theCloudPools[cloudSelector].GetPooledObject();

            newCloud.transform.position = transform.position;
            newCloud.transform.rotation = transform.rotation;
            newCloud.SetActive(true);

        }
    }
}
