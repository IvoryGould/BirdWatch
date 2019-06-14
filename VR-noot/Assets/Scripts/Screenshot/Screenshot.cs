using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public Camera cam;

    // materials for the quads
    public Renderer rendOne;
    public Renderer rendTwo;
    public Renderer rendThree;
    public Renderer polaroid;

    // set this to at least 2, so that the screenshot saves in time
    public int screenshotDelay = 2;

    [HideInInspector]
    public string filename;

    private int screenWidth = 1280;
    private int screenHeight = 720;
    private int screenshotCount = 0;

    private bool screenshotTaken;
    private bool onPolaroid;

    private Texture2D texture = null;

    private void Start()
    {
        cam =  GetComponent<Camera>();
        rendOne = rendOne.GetComponent<Renderer>();
        rendTwo = rendTwo.GetComponent<Renderer>();
        rendThree = rendThree.GetComponent<Renderer>();
        polaroid = polaroid.GetComponent<Renderer>();

        screenshotTaken = false;
        onPolaroid = false;
    }

    private void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && screenshotCount < 3)
        //{
        //    StartCoroutine(ScreenshotCapture());
            
        //}
        /*else*/ if (OVRInput.GetDown(OVRInput.Button.Two) && screenshotTaken)
        {
            // displays screenshots in game
            switch (screenshotCount)
            {
                case 0:
                    rendOne.material.SetTexture("_MainTex", texture);
                    polaroid.material.SetTexture("_MainTex", null);
                    screenshotCount += 1;
                    break;

                case 1:
                    rendTwo.material.SetTexture("_MainTex", texture);
                    polaroid.material.SetTexture("_MainTex", null);
                    screenshotCount += 1;
                    break;

                case 2:
                    rendThree.material.SetTexture("_MainTex", texture);
                    polaroid.material.SetTexture("_MainTex", null);
                    screenshotCount += 1;
                    break;
            }

            screenshotTaken = false;
        }


        if (screenshotTaken && onPolaroid)
        {
            // displays screenshot onto a polaroid
            polaroid.material.SetTexture("_MainTex", texture);
            onPolaroid = false;
        }
    }

    public IEnumerator ScreenshotCapture()
    {
        yield return new WaitForEndOfFrame();
        texture = ScreenCapture.CaptureScreenshotAsTexture();
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        yield return new WaitForSeconds(screenshotDelay);

        screenshotTaken = true;
        onPolaroid = true;

        StopCoroutine(ScreenshotCapture());
    }

}
