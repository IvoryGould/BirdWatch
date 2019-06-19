using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    public Camera cam;

    // materials for quads
    public Renderer clipOne;
    public Renderer clipTwo;
    public Renderer clipThree;

    public Renderer albumOne;
    public Renderer albumTwo;
    public Renderer albumThree;

    // screenshot preview
    public Renderer polaroid;

    // bird layer mask
    public LayerMask birdLayer;

    private int screenshotCount = 0;
    private readonly int screenshotDelay = 2;

    private bool screenshotTaken;
    private bool birdTaken;
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
        screenshotTaken = false;
        onPolaroid = false;
    }


    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !screenshotTaken)
        {
            screenshotTaken = true;
            // distance set to infinite so that there won't be an issue with range
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, birdLayer))
            {             
                birdDetected += "Species" + hit.transform.tag;
                Debug.Log(birdDetected);
                birdTaken = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two) && screenshotTaken)
        {
            switch(birdTaken)
            {
                // displays screenshot onto clipboard
                case true:
                    BirdSaving();
                    break;
                // random screenshots
                case false:
                    NormalSaving();
                    break;
            }
        }
        else if (Input.GetKeyDown("n") && screenshotTaken)
        {
            // deletes screenshot
            PolaroidClear();
        }

        // displays screenshot onto a polaroid
        if (onPolaroid)
        {
            polaroid.material.SetTexture("_MainTex", texture);
            onPolaroid = false;
        }
    }

    public IEnumerator ScreenshotCapture()
    {
        // captures screen, then converts it into a texture
        texture = ScreenCapture.CaptureScreenshotAsTexture();
        yield return new WaitForSeconds(screenshotDelay);

        onPolaroid = true;

        StopCoroutine(ScreenshotCapture());
    }

    private void BirdSaving()
    {
        switch (birdDetected)
        {
            case "SpeciesBird1":
                clipOne.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird2":
                clipTwo.material.SetTexture("_MainTex", texture);          
                break;

            case "SpeciesBird3":
                clipThree.material.SetTexture("_MainTex", texture);
                break;

            default:
                // failsafe
                NormalSaving();
                break;

        }
        PolaroidClear();
    }

    private void NormalSaving()
    {
        switch (screenshotCount)
        {
            case 0:
                albumOne.material.SetTexture("_MainTex", texture);
                break;

            case 1:
                albumTwo.material.SetTexture("_MainTex", texture);
                break;

            case 2:
                albumThree.material.SetTexture("_MainTex", texture);
                break;

            default:
                // failsafe
                albumThree.material.SetTexture("_MainTex", texture);
                break;
        }
        PolaroidClear();
        screenshotCount += 1;
    }

    private void PolaroidClear()
    {
        birdTaken = false;
        screenshotTaken = false;

        texture = null; 
        polaroid.material.SetTexture("_MainTex", null);

        birdDetected = string.Empty;
    }
}
