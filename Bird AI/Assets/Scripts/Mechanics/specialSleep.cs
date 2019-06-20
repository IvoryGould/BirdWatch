using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialSleep : MonoBehaviour
{
    public specialBird sB;
    public static bool sBWakeUp;

    // Start is called before the first frame update
    void Start()
    {
        sBWakeUp = !true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sBWakeUp == true)
        {
            StartCoroutine(WakeUp());
            sBWakeUp = !true;
        }
    }

    IEnumerator WakeUp()
    {
        sB.enabled = !true;
        yield return new WaitForSeconds(Random.Range(30, 40));
        sB.enabled = true;
        sBWakeUp = !true;
        StopCoroutine(WakeUp());
    }
}

