using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 local = transform.localScale;
        transform.localScale = new Vector3(1, 1, 1);

        
        StartCoroutine("Scalestart");
    }
    public IEnumerator Scalestart()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 vec = new Vector3(Mathf.Sqrt(Time.time) * 2f, Mathf.Sqrt(Time.time) * 2f, Mathf.Sqrt(Time.time) * 2f);
        transform.localScale = vec;
        StartCoroutine("Scalestop");
    }

    public IEnumerator Scalestop()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 local = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
    }
}
