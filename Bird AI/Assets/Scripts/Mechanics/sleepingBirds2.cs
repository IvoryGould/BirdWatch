using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepingBirds2 : MonoBehaviour
{
    public rareBird rB;
    public rareBird rB1;
    public rareBird rB2;
    public rareBird rB3;

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
        rB.enabled = false;
        rB1.enabled = false;
        rB2.enabled = false;
        rB3.enabled = false;
        yield return new WaitForSeconds(Random.Range(20, 35));
        rB.enabled = true;
        rB1.enabled = true;
        rB2.enabled = true;
        rB3.enabled = true;
    }
}
