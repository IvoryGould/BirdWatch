using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepingBirds3 : MonoBehaviour
{
    public moveToPoint B;
    public moveToPoint B1;
    public moveToPoint B2;
    public moveToPoint B3;
    public moveToPoint B4;
    public moveToPoint B5;
    public moveToPoint B6;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(WakeUp());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WakeUp()
    {
        // Activate birds
        B.enabled = !true;
        B1.enabled = !true;
        B2.enabled = !true;
        B3.enabled = !true;
        B4.enabled = !true;
        B5.enabled = !true;
        B6.enabled = !true;
        yield return new WaitForSeconds(Random.Range(10, 20));
        B.enabled = true;
        B1.enabled = true;
        B2.enabled = true;
        B3.enabled = true;
        B4.enabled = true;
        B5.enabled = true;
        B6.enabled = true;
    }
}
