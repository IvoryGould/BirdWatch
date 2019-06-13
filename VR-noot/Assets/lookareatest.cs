using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookareatest : MonoBehaviour
{

    public Camera cam;
    public Material redMat;
    public Canvas zoomCanvas;
    public Image zoomOverlay;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        zoomCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            zoomOverlay.enabled = false;
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

        if (OVRInput.Get(OVRInput.Button.One))
        {

            zoomCanvas.enabled = true;

        }
        else {

            zoomCanvas.enabled = false;

        }

    }
}
