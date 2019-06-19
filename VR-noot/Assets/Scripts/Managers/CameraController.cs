using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject playCamera;
    public GameObject menuCamera;

    private void Awake()
    {

        playCamera = GameObject.Find("OVRCameraRig Play");
        menuCamera = GameObject.Find("OVRCameraRig Menu");

        //audioClick = Resources.Load("Audio/Click") as AudioClip;

    }

    private void Start()
    {

        playCamera.SetActive(false);

    }

    private void Update()
    {
        


    }

    public void MovePlayerToStage() {

        //source.PlayOneShot(audioClick);

        playCamera.SetActive(true);
        menuCamera.SetActive(false);

    }

}
