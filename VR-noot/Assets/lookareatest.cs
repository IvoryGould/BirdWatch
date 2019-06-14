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

    bool zoomToggle = false;

    private Screenshot screenshot;

    // Start is called before the first frame update
    void Start()
    {
        screenshot = GameObject.Find("ZoomCam").GetComponent<Screenshot>();
        cam = GetComponent<Camera>();
        zoomCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        RaycastHit hit;

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

            if (Physics.Raycast(ray, out hit) && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){

                zoomOverlay.enabled = false;
                StartCoroutine(screenshot.ScreenshotCapture());

                if (hit.transform.tag == "bird")
                {
                    if (hit.collider.gameObject.GetComponent<MeshRenderer>().material.color != Color.cyan)
                    {
                        hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    }
                    else if (hit.collider.gameObject.GetComponent<MeshRenderer>().material.color == Color.cyan)
                    {

                        hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

                    }
                }
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
