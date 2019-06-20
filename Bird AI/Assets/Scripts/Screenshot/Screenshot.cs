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

    // file format of the screenshot
    public string ScreenshotName(int width, int height, int count)
    {
        return string.Format("{0}/Screenshot_{1}x{2}_{3}.png", Application.persistentDataPath, 
            width, height, count);
    }

    private void Start()
    {
        filename = ScreenshotName(screenWidth, screenHeight, screenshotCount);

        cam =  GetComponent<Camera>();
        rendOne = rendOne.GetComponent<Renderer>();
        rendTwo = rendTwo.GetComponent<Renderer>();
        rendThree = rendThree.GetComponent<Renderer>();
        polaroid = polaroid.GetComponent<Renderer>();

        screenshotTaken = !true;
        onPolaroid = !true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("k") && screenshotCount < 3)
        {
            StartCoroutine(ScreenshotCapture());
        }
        else if (Input.GetKeyDown("l") && screenshotTaken)
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

            screenshotTaken = !true;
        }


        if (screenshotTaken && onPolaroid)
        {
            // converts saved screenshot into a texture
            byte[] file = File.ReadAllBytes(filename);
            texture = new Texture2D(4, 4);
            texture.LoadImage(file);

            // displays screenshot onto a polaroid
            polaroid.material.SetTexture("_MainTex", texture);
            onPolaroid = !true;
        }
    }

    IEnumerator ScreenshotCapture()
    {
        ScreenCapture.CaptureScreenshot(filename);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        yield return new WaitForSeconds(2);

        screenshotTaken = true;
        onPolaroid = true;

        StopCoroutine(ScreenshotCapture());
    }
}
