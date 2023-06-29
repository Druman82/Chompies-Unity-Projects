using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestroyerMenu : MonoBehaviour
{
    public GameObject cloudDestructionPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float distanceOf;
    public float distanceAt;
    private bool replaced;
    public GameObject Sphere;

    // fade speed length
    public float fadeSpeed;

    //Pause length between fades
    public int fadePause;

    void Start()
    {
        cloudDestructionPoint = GameObject.Find("CloudDestructionPoint");
    }

    void Update()
    {
        distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

        distanceOf = Random.Range(-200, 300);

        distanceAt = Random.Range(100, 150);

        if (transform.position.z < cloudDestructionPoint.transform.position.z)
        {
            replaced = true;
            //gameObject.SetActive(false);
            StartCoroutine("FadeOut");
            StartCoroutine("Replace");
            //StartCoroutine("Fade");
        }
    }

    IEnumerator FadeOut()
    {
        var material = Sphere.GetComponent<Renderer>().material;
        //forever
        //while (true)
        //{
            // fade out
            yield return Fade(material, 0);
            // wait
            //yield return new WaitForSeconds(fadePause);
        //}
    }

    IEnumerator Replace()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine("FadeIn");
        if (replaced == true)
        {
            replaced = false;
            transform.position = new Vector3(distanceOf, distanceAt, 600);
        }
    }

    IEnumerator FadeIn()
    {
        var material = Sphere.GetComponent<Renderer>().material;

        // fade in
        yield return Fade(material, 1);
            // wait
            yield return new WaitForSeconds(fadePause);
    }

    IEnumerator Fade(Material mat, float targetAlpha)
    {
        while (mat.color.a != targetAlpha)
        {
            var newAlpha = Mathf.MoveTowards(mat.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newAlpha);
            yield return null;
        }
    }
}
