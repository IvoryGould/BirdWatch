using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The Game Manager handles everything Gameplay-wise. A state machine that tells what actions happen, what functions are called, etc. Most functions are linked to their corresponding scripts.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Player Locations")]
    public GameObject _wpHome;
    public GameObject _wpStage;
    
    private bool _isPlaying;
    private bool _isPaused;
    private bool _isPreviewing;
    //private bool _snapPhoto = !true;

    // classes
    UIController UIController;
    CameraController CameraController;
    UIAnimationManager UIAnimationManager;

    public static AudioSource SFXSource;

    public void Awake()
    {
        _isPlaying = !true;
        _isPaused = !true;
        _isPreviewing = !true;

        // finds AudioSource attached to camera.
        SFXSource = GameObject.Find("CAM_Main").GetComponent<AudioSource>();

        UIController = GetComponent<UIController>();
        CameraController = GetComponent<CameraController>();
        UIAnimationManager = GetComponent<UIAnimationManager>();
    }

    private void Start()
    {
        UIController.CvsMainMenu.enabled = true;
        UIController.CvsPauseMenu.enabled = !true;
        UIController.StartGame();
    }

    public void Update()
    {
        // PAUSE FUNCTION (Debug)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isPlaying == true)
            {
                if (_isPaused == !true)
                {
                    _isPaused = true;
                    UIController.Pause_Main();
                    Debug.Log("Game Paused");
                }

                else if (_isPaused == true)
                {
                    _isPaused = !true;
                    UIController.Pause_Resume();
                    Debug.Log("Game Resumed");
                }
            }
        }

        // Placeholder Snapping
        if (Input.GetKeyDown(KeyCode.Home))
        {
            if (_isPreviewing == !true)
            {
                _isPreviewing = true;
                SFXSource.PlayOneShot(UIController._sFXSnap);
                UIAnimationManager.TakePhoto();
            }
        }

        // State Debug
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.Log("Playing:" + _isPlaying + " || Paused: " + _isPaused + " || Options: " + UIController._options);
            Debug.Log("Snapshot Taken:" + UIAnimationManager._fireCamera);
        }
    }
    
    public void PlayGame()
    {
        _isPaused = !true;
        _isPlaying = true;

        Debug.Log("FAKESTART GAME");
        Debug.Log("PRESS SPACE TO PAUSE - TEMP");

        UIController.CvsMainMenu.enabled = !true;
        CameraController.MovePlayerToStage(_wpStage);

        UIController.SelectionReset();
    }

    public void EndSession()
    {
        _isPlaying = !true;
        _isPaused = !true;

        UIController.CvsPauseMenu.enabled = !true;
        UIController.CvsMainMenu.enabled = true;
        CameraController.MovePlayerToMenu(_wpHome);

        UIController.SelectionReset();
    }

    public void ResumeGame()
    {
        UIController.Pause_Resume();
        _isPaused = !true;

        UIController.SelectionReset();
    }
    
    public void ReturnFromPhoto()
    {
        SFXSource.PlayOneShot(UIController._sFXKeep);
        _isPreviewing = !true;
        UIAnimationManager.PhotoAccept();
    }

    public void QuitGame()          // Cancels Editor Playtest or Closes application. :)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = !true;
#else
         Application.Quit();
#endif
    }

}
