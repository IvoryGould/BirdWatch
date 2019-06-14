﻿using System.Collections;
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
    
    private bool _isPlaying = false;
    private bool _isPaused = false;
    //private bool _snapPhoto = false;

    UIController UIController;
    CameraController CameraController;
    UIAnimationManager UIAnimationManager;

    private void Awake()
    {
        _isPlaying = false;
        _isPaused = false;

        UIController = GetComponent<UIController>();
        CameraController = GetComponent<CameraController>();
        UIAnimationManager = GetComponent<UIAnimationManager>();
    }

    private void Start()
    {
        UIController.CvsMainMenu.enabled = true;
        UIController.Main_Menu();
        UIController.Pause_Resume();
        UIController.CvsPauseMenu.enabled = false;
    }

    public void Update()
    {
        // PAUSE FUNCTION (Debug)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isPlaying == true)
            {
                if (_isPaused == false)
                {
                    _isPaused = true;
                    UIController.Pause_Main();
                    Debug.Log("Game Paused");
                }

                else if (_isPaused == true)
                {
                    _isPaused = false;
                    UIController.Pause_Resume();
                    Debug.Log("Game Resumed");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Home))
        {
            UIAnimationManager.PhotoAnim();
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
        _isPaused = false;
        _isPlaying = true;

        Debug.Log("FAKESTART GAME");
        Debug.Log("PRESS SPACE TO PAUSE - TEMP");

        UIController.CvsMainMenu.enabled = false;
        CameraController.MovePlayerToStage(_wpStage);

        UIController.SelectionReset();
    }

    public void EndSession()
    {
        _isPlaying = false;
        _isPaused = false;

        UIController.CvsPauseMenu.enabled = false;
        UIController.CvsMainMenu.enabled = true;
        CameraController.MovePlayerToMenu(_wpHome);

        UIController.SelectionReset();
    }

    public void ResumeGame()
    {
        UIController.Pause_Resume();
        _isPaused = false;

        UIController.SelectionReset();
    }

    public void TakePhoto()
    {

    }

    public void ReturnFromPhoto()
    {

    }

    public void QuitGame()          // Cancels Editor Playtest or Closes application. :)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}
