using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    public Camera cam;

    // materials for quads
    public Renderer clipPhotoOne, clipPhotoTwo, clipPhotoThree, clipPhotoFour, clipPhotoFive, 
                    clipPhotoSix, clipPhotoSeven, clipPhotoEight, clipPhotoNine, clipPhotoTen;

    public Renderer extraPhotoOne, extraPhotoTwo, extraPhotoThree, extraPhotoFour, extraPhotoFive,
                    extraPhotoSix, extraPhotoSeven, extraPhotoEight, extraPhotoNine, extraPhotoTen;

    // screenshot preview
    public Image polaroid;
    private Sprite polaroidSprite;

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
        RenderGet();

        cam =  GetComponent<Camera>();

        polaroid.enabled = false;

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
            polaroid.sprite = polaroidSprite;

            onPolaroid = false;
        }
    }

    public IEnumerator ScreenshotCapture()
    {
        // captures screen, then converts it into a texture
        texture = ScreenCapture.CaptureScreenshotAsTexture();
        yield return new WaitForSeconds(screenshotDelay);

        polaroid.enabled = true;
        polaroidSprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(1f, 1f), 128f);

        onPolaroid = true;

        StopCoroutine(ScreenshotCapture());
    }

    private void BirdSaving()
    {
        switch (birdDetected)
        {
            case "SpeciesBird1":
                clipPhotoOne.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird2":
                clipPhotoTwo.material.SetTexture("_MainTex", texture);          
                break;

            case "SpeciesBird3":
                clipPhotoThree.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird4":
                clipPhotoFour.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird5":
                clipPhotoFive.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird6":
                clipPhotoSix.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird7":
                clipPhotoSeven.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird8":
                clipPhotoEight.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird9":
                clipPhotoNine.material.SetTexture("_MainTex", texture);
                break;

            case "SpeciesBird10":
                clipPhotoTen.material.SetTexture("_MainTex", texture);
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
                extraPhotoOne.material.SetTexture("_MainTex", texture);
                break;

            case 1:
                extraPhotoTwo.material.SetTexture("_MainTex", texture);
                break;

            case 2:
                extraPhotoThree.material.SetTexture("_MainTex", texture);
                break;

            case 3:
                extraPhotoFour.material.SetTexture("_MainTex", texture);
                break;

            case 4:
                extraPhotoFive.material.SetTexture("_MainTex", texture);
                break;

            case 5:
                extraPhotoSix.material.SetTexture("_MainTex", texture);
                break;

            case 6:
                extraPhotoSeven.material.SetTexture("_MainTex", texture);
                break;

            case 7:
                extraPhotoEight.material.SetTexture("_MainTex", texture);
                break;

            case 8:
                extraPhotoNine.material.SetTexture("_MainTex", texture);
                break;

            case 9:
                extraPhotoTen.material.SetTexture("_MainTex", texture);
                break;

            default:
                // failsafe
                extraPhotoTen.material.SetTexture("_MainTex", texture);
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
        polaroid.sprite = null;
        polaroid.enabled = false;

        birdDetected = string.Empty;
    }

    private void RenderGet()
    {
        // clipboard photos
        clipPhotoOne = clipPhotoOne.GetComponent<Renderer>();
        clipPhotoTwo = clipPhotoTwo.GetComponent<Renderer>();
        clipPhotoThree = clipPhotoThree.GetComponent<Renderer>();
        clipPhotoFour = clipPhotoFour.GetComponent<Renderer>();
        clipPhotoFive = clipPhotoFive.GetComponent<Renderer>();
        clipPhotoSix = clipPhotoSix.GetComponent<Renderer>();
        clipPhotoSeven = clipPhotoSeven.GetComponent<Renderer>();
        clipPhotoEight = clipPhotoEight.GetComponent<Renderer>();
        clipPhotoNine = clipPhotoNine.GetComponent<Renderer>();
        clipPhotoTen = clipPhotoTen.GetComponent<Renderer>();

        // random photos
        extraPhotoOne = extraPhotoOne.GetComponent<Renderer>();
        extraPhotoTwo = extraPhotoTwo.GetComponent<Renderer>();
        extraPhotoThree = extraPhotoThree.GetComponent<Renderer>();
        extraPhotoFour = extraPhotoFour.GetComponent<Renderer>();
        extraPhotoFive = extraPhotoFive.GetComponent<Renderer>();
        extraPhotoSix = extraPhotoSix.GetComponent<Renderer>();
        extraPhotoSeven = extraPhotoSeven.GetComponent<Renderer>();
        extraPhotoEight = extraPhotoEight.GetComponent<Renderer>();
        extraPhotoNine = extraPhotoNine.GetComponent<Renderer>();
        extraPhotoTen = extraPhotoTen.GetComponent<Renderer>();
    }
}
