using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialSleep : MonoBehaviour
{
    public specialBird sB;
    public specialBird2 sB2;
    public specialBird3 sB3;
    public static bool sBWakeUp;
    public static bool sBWakeUp2;
    public static bool sBWakeUp3;

    // Start is called before the first frame update
    void Start()
    {
        sBWakeUp = false;
        sBWakeUp2 = false;
        sBWakeUp3 = false;
        // Disable birds at start
        StartCoroutine(WakeUp());
        StartCoroutine(WakeUp2());
        StartCoroutine(WakeUp3());
    }

    // Update is called once per frame
    void Update()
    {
        // Activate first special bird
        if (sBWakeUp == true)
        {
            StartCoroutine(WakeUp());
            sBWakeUp = false;
        }
        // Activate second special bird
        if(sBWakeUp2 == true)
        {
            StartCoroutine(WakeUp2());
            sBWakeUp2 = false;
        }
        // Activate third special bird
        if(sBWakeUp3 == true)
        {
            StartCoroutine(WakeUp3());
            sBWakeUp3 = false;
        }
    }

    IEnumerator WakeUp()
    {
        // Disable first special bird
        sB.enabled = false;
        yield return new WaitForSeconds(Random.Range(30, 40));
        sB.enabled = true;
        sBWakeUp = false;
        StopCoroutine(WakeUp());
    }

    IEnumerator WakeUp2()
    {
        // Disable second special bird
        sB2.enabled = false;
        yield return new WaitForSeconds(Random.Range(15, 30));
        sB2.enabled = true;
        sBWakeUp2 = false;
        StopCoroutine(WakeUp2());
    }

    IEnumerator WakeUp3()
    {
        // Disable third special bird
        sB3.enabled = false;
        yield return new WaitForSeconds(Random.Range(10, 20));
        sB3.enabled = true;
        sBWakeUp3 = false;
        StopCoroutine(WakeUp3());
    }
}

