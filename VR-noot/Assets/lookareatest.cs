using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookareatest : MonoBehaviour
{

    public Camera cam;
    public Camera zoomCamera;
    public Material redMat;
    public Canvas zoomCanvas;
    public Image zoomOverlay;

    //private Canvas pauseMenu;

    private UIController uIController;

    bool zoomToggle = false;
    bool pauseToggle = false;

    private Screenshot screenshot;

    private void Awake()
    {
        
        //pauseMenu = GameObject.Find("CANVAS PauseMenu").GetComponent<Canvas>();
        uIController = GameObject.Find("MENUS Controller").GetComponent<UIController>();

    }

    // Start is called before the first frame update
    void Start()
    {
        screenshot = GameObject.Find("ZoomCam").GetComponent<Screenshot>();
        cam = GetComponent<Camera>();
        zoomCanvas.enabled = false;

        //pauseMenu.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        OVRInput.Update();

        if (OVRInput.GetDown(OVRInput.Button.Back))
        {

            pauseToggle = !pauseToggle;

        }

        if (pauseToggle == true)
        {

            uIController.Pause_Main();
            //pauseMenu.enabled = true;

        }
        else {

            uIController.Pause_Resume();
            //pauseMenu.enabled = false;

        }

        if (OVRInput.GetDown(OVRInput.Button.One))
            zoomToggle = !zoomToggle;

        if (zoomToggle == true)
        {

            zoomCanvas.enabled = true;
            zoomCamera.fieldOfView -= OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).y;
            if (zoomCamera.fieldOfView < 20)
            {

                zoomCamera.fieldOfView = 20;

            }
            else if (zoomCamera.fieldOfView > 130) {

                zoomCamera.fieldOfView = 130;

            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){

                zoomOverlay.enabled = false;
                StartCoroutine(screenshot.ScreenshotCapture());

            }
            else {

                zoomOverlay.enabled = true;

            }

        }
        else {

            zoomCanvas.enabled = false;

        }

    }
}
