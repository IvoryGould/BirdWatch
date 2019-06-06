using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public Camera cam;

    // Materials for the quads
    public Renderer rendOne;
    public Renderer rendTwo;
    public Renderer rendThree;

    [HideInInspector]
    public string filename;

    private int screenWidth = 1280;
    private int screenHeight = 720;
    private int screenshotCount = 0;

    private bool screenshotTaken;

    private Texture2D texture = null;
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

        screenshotTaken = false;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown("k") && screenshotCount < 3)
        {
            StartCoroutine(ScreenshotCapture());
        }
        else if (Input.GetKeyDown("l") && screenshotTaken)
        {

            byte[] file = File.ReadAllBytes(filename);
            texture = new Texture2D(4, 4);
            texture.LoadImage(file);

            switch (screenshotCount)
            {
                case 0:
                    rendOne.material.SetTexture("_MainTex", texture);
                    screenshotCount += 1;
                    break;

                case 1:
                    rendTwo.material.SetTexture("_MainTex", texture);
                    screenshotCount += 1;
                    break;

                case 2:
                    rendThree.material.SetTexture("_MainTex", texture);
                    screenshotCount += 1;
                    break;
            }

            screenshotTaken = false;
        }
    }

    IEnumerator ScreenshotCapture()
    {
        ScreenCapture.CaptureScreenshot(filename);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        yield return null;

        screenshotTaken = true;

        StopCoroutine(ScreenshotCapture());
    }
}
