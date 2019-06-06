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

    public string filename;

    private int screenWidth = 1280;
    private int screenHeight = 720;
    private int screenshotCount = 0;

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
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown("k") && screenshotCount < 3)
        {
            screenshotCount += 1;
            StartCoroutine(ScreenshotCapture());
        }
        else if (Input.GetKeyDown("l"))
        {
            byte[] file = File.ReadAllBytes(filename);
            texture = new Texture2D(4, 4);
            texture.LoadImage(file);

            switch (screenshotCount)
            {
                case 1:
                    rendOne.material.SetTexture("_MainTex", texture);
                    break;

                case 2:
                    rendTwo.material.SetTexture("_MainTex", texture);
                    break;

                case 3:
                    rendThree.material.SetTexture("_MainTex", texture);
                    break;
            }
        }

      
    }

    IEnumerator ScreenshotCapture()
    {
        ScreenCapture.CaptureScreenshot(filename);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        yield return null;

        StopCoroutine(ScreenshotCapture());

    }
}
