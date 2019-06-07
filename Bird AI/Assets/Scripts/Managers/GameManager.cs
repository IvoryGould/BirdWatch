using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    void Awake()
    {
        _isPlaying = false;

        UIController = GameObject.Find("MENUS Controller").GetComponent<UIController>();
        CameraController = GameObject.Find("CAMERA Controller").GetComponent<CameraController>();

    }

    public void PlayGame()
    {
        //Debug.Log("FAKESTART GAME");
        UIController.CvsMainMenu.enabled = false;
        CameraController.MovePlayerToStage(_wpStage);
    }
}
