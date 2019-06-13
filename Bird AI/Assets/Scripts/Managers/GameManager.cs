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

        UIController = GameObject.Find("MENU Controller").GetComponent<UIController>();
        CameraController = GameObject.Find("CAMERA Controller").GetComponent<CameraController>();
    }

    public void PlayGame()
    {
        Debug.Log("FAKESTART GAME");
        Debug.Log("PRESS SPACE TO PAUSE - TEMP");
        _isPlaying = true;

        UIController.CvsMainMenu.enabled = false;
        CameraController.MovePlayerToStage(_wpStage);
    }

    public void EndGame()
    {
        _isPlaying = false;

        UIController.ExitToMainMenu();
        CameraController.MovePlayerToMenu(_wpHome);
    }

    public void QuitGame()                  // Cancels Editor Playtest or Closes application. :)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
