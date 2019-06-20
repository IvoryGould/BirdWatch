using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepingBirds : MonoBehaviour
{
    public rarerBird rrB;
    public rarerBird rrB1;
    public rarerBird rrB2;

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
        rrB.enabled = !true;
        rrB1.enabled = !true;
        rrB2.enabled = !true;
        yield return new WaitForSeconds(Random.Range(30, 50));
        rrB.enabled = true;
        rrB1.enabled = true;
        rrB2.enabled = true;
    }
}
