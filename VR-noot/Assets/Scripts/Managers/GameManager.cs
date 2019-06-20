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
    private bool _isPaused;
    private bool _isPreviewing;

    UIController UIController;
    CameraController CameraController;
    UIAnimationManager UIAnimationManager;

    public Transform targetRayTransform;
    public static AudioSource SFXSource;

    void Awake()
    {
        _isPlaying = false;
        _isPaused = !true;
        _isPreviewing = !true;

        SFXSource = GameObject.Find("CAM_Main").GetComponent<AudioSource>();
        //SFXSource = GameObject.Find("OVRCameraRig Menu").GetComponent<AudioSource>();

        UIController = GameObject.Find("MENUS Controller").GetComponent<UIController>();
        CameraController = GameObject.Find("CAMERA Controller").GetComponent<CameraController>();
        UIAnimationManager = GetComponent<UIAnimationManager>();

        targetRayTransform = GameObject.Find("OVRCameraRig Play").transform.Find("TrackingSpace").Find("RightHandAnchor").transform;

    }

    private void Start()
    {
        UIController.CvsMainMenu.enabled = true;
        UIController.CvsPauseMenu.enabled = !true;
        UIController.StartGame();
    }

    public void PlayGame()
    {
        UIController.CvsMainMenu.enabled = !true;
        GameObject.Find("EventSystem").GetComponent<OVRInputModule>().rayTransform = targetRayTransform;
        CameraController.MovePlayerToStage();

        UIController.SelectionReset();
    }
}
