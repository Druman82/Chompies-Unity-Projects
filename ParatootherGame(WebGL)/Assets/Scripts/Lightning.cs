using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject[] flickeringLights;
    public AudioSource thunder1;
    public AudioSource thunder2;
    public AudioSource thunder3;
    public AudioSource thunder4;
    public AudioSource thunder5;
    public AudioSource thunder6;
    public int thunder;

    Light lights;
    public float minFlickerTime = 0.1f;
    public float maxFlickerTime = 0.4f;
    private bool flicker;
    public bool lightsOn = true;

    void Start()
    {
        flickeringLights = GameObject.FindGameObjectsWithTag("FlickeringLight");
        for (int i = 0; i < flickeringLights.Length; i++)
        lights = flickeringLights[i].GetComponent<Light>();
        StartCoroutine(LightsOff(lights));
    }

    IEnumerator Flash()
    {
        if (lightsOn == true)
        {
            {
                flickeringLights = GameObject.FindGameObjectsWithTag("FlickeringLight");
                for (int i = 0; i < flickeringLights.Length; i++)
                lights = flickeringLights[i].GetComponent<Light>();
                StopCoroutine(LightsOff(lights));
                StartCoroutine(Flicker(lights));
                yield return new WaitForSeconds(Random.Range(1, 2));
                thunder = Random.Range(1, 7);
                if (Settings.soundFXBool == true)
                {
                    if (thunder == 1)
                    {
                        yield return new WaitForSeconds(Random.Range(2, 7));
                        thunder1.Play();
                    }
                    else if (thunder == 2)
                    {
                        yield return new WaitForSeconds(Random.Range(2, 7));
                        thunder2.Play();
                    }
                    else if (thunder == 3)
                    {
                        yield return new WaitForSeconds(Random.Range(2, 7));
                        thunder3.Play();
                    }
                    else if (thunder == 4)
                    {
                        yield return new WaitForSeconds(Random.Range(2, 7));
                        thunder4.Play();
                    }
                    else if (thunder == 5)
                    {
                        yield return new WaitForSeconds(Random.Range(2, 7));
                        thunder5.Play();
                    }
                    else if (thunder == 6)
                    {
                        yield return new WaitForSeconds(Random.Range(2, 7));
                        thunder6.Play();
                    }
                }

                lightsOn = false;
                if (lights.enabled)
                {
                    lights.enabled = !lights.enabled;
                }
                StopCoroutine(Flicker(lights));
                StartCoroutine(LightsOff(lights));
            }
        }
        else if (lightsOn == false)
        {
            StartCoroutine(LightsOff(lights));
        }
    }

    IEnumerator Flicker(Light lights)
    {
        while (lightsOn)
        {
            yield return new WaitForSeconds(Random.Range(minFlickerTime, maxFlickerTime));
            lights.enabled = !lights.enabled;
        }
    }

    IEnumerator LightsOff(Light lights)
    {
        lights.enabled = !lights.enabled;
        StopCoroutine("Flash");
        yield return new WaitForSeconds(Random.Range(4, 20));
        lightsOn = true;
        StartCoroutine("Flash");
    }
}
