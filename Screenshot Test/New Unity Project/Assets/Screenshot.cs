using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    public Camera cam;

    // materials for the quads
    public Renderer clipOne;
    public Renderer clipTwo;
    public Renderer clipThree;

    public Renderer albumOne;
    public Renderer albumTwo;
    public Renderer albumThree;

    public Renderer polaroid;

    // bird layer mask
    public LayerMask birdLayer;

    // set this to at least 2, so that the screenshot saves in time
    private int screenshotDelay = 2;
    private int screenshotCount = 0;

    private bool birdTaken;
    private bool normalTaken;
    private bool onPolaroid;

    private string birdDetected;

    private Texture2D texture = null;

    private void Start()
    {
        cam =  GetComponent<Camera>();
        clipOne = clipOne.GetComponent<Renderer>();
        clipTwo = clipTwo.GetComponent<Renderer>();
        clipThree = clipThree.GetComponent<Renderer>();

        albumOne = albumOne.GetComponent<Renderer>();
        albumTwo = albumTwo.GetComponent<Renderer>();
        albumThree = albumThree.GetComponent<Renderer>();

        polaroid = polaroid.GetComponent<Renderer>();


        birdTaken = false;
        normalTaken = false;
        onPolaroid = false;
    }


    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        // distance set to infinite so that there won't be an issue with range
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, birdLayer) && Input.GetKeyDown("k"))
        {
            birdDetected = "Species" + hit.transform.tag;
            StartCoroutine(ScreenshotCapture());
            Debug.Log("Hit Species " + birdDetected);
            birdTaken = true;
        }
        else if(screenshotCount < 3 && Input.GetKeyDown("k"))
        {
            StartCoroutine(ScreenshotCapture());
            Debug.Log("Normal Screenshot");
            normalTaken = true;
        }

        // displays screenshot onto clipboard
        if (Input.GetKeyDown("y") && birdTaken)
            BirdSaving();
        else if (Input.GetKeyDown("n") && birdTaken)
        {
            texture = null;
            polaroid.material.SetTexture("_MainTex", null);
            birdTaken = false;
        }

        if (Input.GetKeyDown("y") && normalTaken)
            NormalSaving();
        else if(Input.GetKeyDown("n") && normalTaken)
        {
            texture = null;
            polaroid.material.SetTexture("_MainTex", null);
            normalTaken = false;
        }

        // displays screenshot onto a polaroid
        if (onPolaroid)
        {
            polaroid.material.SetTexture("_MainTex", texture);
            onPolaroid = false;
        }
    }

    IEnumerator ScreenshotCapture()
    {
        texture = ScreenCapture.CaptureScreenshotAsTexture();
        Debug.Log(string.Format("Took a screenshot"));
        yield return new WaitForSeconds(2);

        onPolaroid = true;

        StopCoroutine(ScreenshotCapture());
    }

    private void BirdSaving()
    {
        switch (birdDetected)
        {
            case "SpeciesBird1":
                clipOne.material.SetTexture("_MainTex", texture);
                polaroid.material.SetTexture("_MainTex", null);
                birdTaken = false;
                break;

            case "SpeciesBird2":
                clipTwo.material.SetTexture("_MainTex", texture);
                polaroid.material.SetTexture("_MainTex", null);
                birdTaken = false;
                break;

            case "SpeciesBird3":
                clipThree.material.SetTexture("_MainTex", texture);
                polaroid.material.SetTexture("_MainTex", null);
                birdTaken = false;
                break;
        }
    }

    private void NormalSaving()
    {
        switch (screenshotCount)
        {
            case 0:
                albumOne.material.SetTexture("_MainTex", texture);
                polaroid.material.SetTexture("_MainTex", null);
                screenshotCount += 1;
                normalTaken = false;
                break;

            case 1:
                albumTwo.material.SetTexture("_MainTex", texture);
                polaroid.material.SetTexture("_MainTex", null);
                screenshotCount += 1;
                normalTaken = false;
                break;

            case 2:
                albumThree.material.SetTexture("_MainTex", texture);
                polaroid.material.SetTexture("_MainTex", null);
                screenshotCount += 1;
                normalTaken = false;
                break;
        }
    }
}
