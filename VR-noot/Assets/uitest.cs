using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uitest : MonoBehaviour
{

    public GameObject testText;

    // Start is called before the first frame update
    void Start()
    {

        testText.GetComponent<Text>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void TestTextActivate() {

        testText.GetComponent<Text>().enabled = true;

    }

}
