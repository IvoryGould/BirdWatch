using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookareatest : MonoBehaviour
{

    public Camera cam;
    public Material redMat;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            if (hit.transform.tag == "bird") {
                if (hit.collider.gameObject.GetComponent<MeshRenderer>().material.color != Color.cyan)
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                }
                else if (hit.collider.gameObject.GetComponent<MeshRenderer>().material.color == Color.cyan) {

                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

                }
            }
    }
}
