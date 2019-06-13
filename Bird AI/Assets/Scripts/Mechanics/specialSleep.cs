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
        sBWakeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sBWakeUp == true)
        {
            StartCoroutine(WakeUp());
            sBWakeUp = false;
        }
    }

    IEnumerator WakeUp()
    {
        sB.enabled = false;
        yield return new WaitForSeconds(Random.Range(5,6));
        sB.enabled = true;
        sBWakeUp = false;
        StopCoroutine(WakeUp());
    }
}
