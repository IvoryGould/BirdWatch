using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Player Locations")]
    [SerializeField]
        private GameObject _wpHome;
    [SerializeField]
        private GameObject _wpStage;
    
    public static bool _isPlaying;

    UIController UIController;
    CameraController CameraController;

    public Transform tragetRayTransfrom;

    void Awake()
    {
        _isPlaying = false;

        UIController = GameObject.Find("MENUS Controller").GetComponent<UIController>();
        CameraController = GameObject.Find("CAMERA Controller").GetComponent<CameraController>();

        tragetRayTransfrom = GameObject.Find("OVRCameraRig Play").transform.Find("TrackingSpace").Find("RightHandAnchor").transform;

    }

    public void PlayGame()
    {
        //Debug.Log("FAKESTART GAME");
        UIController.CvsMainMenu.enabled = false;
        GameObject.Find("EventSystem").GetComponent<OVRInputModule>().rayTransform = tragetRayTransfrom;
        CameraController.MovePlayerToStage();
    }
}
