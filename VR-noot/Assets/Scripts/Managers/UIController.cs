using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// The UI Controller handles all the UI elements in the game. Commands work stand-alone; however some are called by the Game Manager.
/// </summary>

public class UIController : MonoBehaviour
{
    [Header("EventSystem")]
    public GameObject EventSystemSlot;

    [Header("Canvas Controllers")]
    public Canvas CvsMainMenu;
    public Canvas CvsPauseMenu;

    [Header("Main Menu Slots")]
    public GameObject MenuMain;
    public GameObject MenuOptions;
    public GameObject MenuCredits;
    public GameObject MenuConfirmExit;

    [Header("Pause Menu Slots")]
    public GameObject PauseMain;
    public GameObject PauseOptions;
    public GameObject PauseConfirmExit;

    [Header("AudioClips")]
    public static AudioClip _sFXEnter;
    public static AudioClip _sFXLeave;
    public static AudioClip _sFXSnap;
    public static AudioClip _sFXHover;
    public static AudioClip _sFXKeep;

    GameManager GameManager;
    CameraController cameraController;

    public bool _options = !true;      // safety for slider functionality



    // HERE ARE THE FUNCTIONS FOR THE MAIN MENU

    public void Awake()
    {
        StartGame();
        GameManager = GetComponent<GameManager>();
        _sFXEnter = Resources.Load("SFX/FX51 - Select 1") as AudioClip;
        _sFXLeave = Resources.Load("SFX/FX51 - Select 4") as AudioClip;
        _sFXSnap = Resources.Load("SFX/Camera_Polaroid") as AudioClip;
        _sFXHover = Resources.Load("SFX/UIHover") as AudioClip;
        _sFXKeep = Resources.Load("SFX/PaperTurn") as AudioClip;
        cameraController = GameObject.Find("CAMERA Controller").GetComponent<CameraController>();

    }



    public void Main_Menu()           // Switch menus back to Main Menu + failsafe for loose UI panels. 
    {
        //GameManager.SFXSource.PlayOneShot(_sFXLeave);

        MenuMain.SetActive(true);
        MenuOptions.SetActive(!true);
        MenuCredits.SetActive(!true);
        MenuConfirmExit.SetActive(!true);
        _options = !true;

        SelectionReset();
    }

    public void Main_Options()        // Switch to Options, Closes Main Menu Panel.
    {
        //GameManager.SFXSource.PlayOneShot(_sFXEnter);
        MenuMain.SetActive(!true);
        MenuOptions.SetActive(true);
        _options = true;

        SelectionReset();
    }

    public void Main_Credits()            // Switch to Credits, Closes Main Menu Panel.
    {
        //GameManager.SFXSource.PlayOneShot(_sFXEnter);
        MenuMain.SetActive(!true);
        MenuCredits.SetActive(true);

        SelectionReset();
    }

    public void Main_ConfirmExit()        // Opens Exit Confirm Panel.
    {
        //GameManager.SFXSource.PlayOneShot(_sFXEnter);
        MenuConfirmExit.SetActive(true);

        SelectionReset();
    }

    // HERE ARE THE FUNCTIONS FOR THE PAUSE MENU

    public void Pause_Main()
    {
        //GameManager.SFXSource.PlayOneShot(_sFXEnter);
        CvsPauseMenu.enabled = true;
        PauseMain.SetActive(true);
        PauseOptions.SetActive(!true);
        PauseConfirmExit.SetActive(!true);
        _options = !true;

        SelectionReset();
    }

    public void Pause_Resume()
    {
        //GameManager.SFXSource.PlayOneShot(_sFXLeave);

        PauseMain.SetActive(!true);
        PauseOptions.SetActive(!true);
        PauseConfirmExit.SetActive(!true);
        CvsPauseMenu.enabled = !true;

        SelectionReset();
    }

    public void Pause_Options()
    {
        //GameManager.SFXSource.PlayOneShot(_sFXEnter);

        PauseMain.SetActive(!true);
        PauseOptions.SetActive(true);
        _options = true;

        SelectionReset();
    }

    public void Pause_ConfirmExit()
    {
        //GameManager.SFXSource.PlayOneShot(_sFXEnter);

        PauseConfirmExit.SetActive(true);

        SelectionReset();
    }

    public void Pause_ExitToMain()
    {
        //GameManager.SFXSource.PlayOneShot(_sFXLeave);

        CvsPauseMenu.enabled = !true;
        CvsMainMenu.enabled = true;

        cameraController.playCamera.SetActive(false);
        cameraController.menuCamera.SetActive(true);

        SelectionReset();
    }

    //

    public void StartGame()
    {
        MenuMain.SetActive(true);
        MenuOptions.SetActive(!true);
        MenuCredits.SetActive(!true);
        MenuConfirmExit.SetActive(!true);
        _options = !true;
        PauseMain.SetActive(!true);
        PauseOptions.SetActive(!true);
        PauseConfirmExit.SetActive(!true);
        CvsPauseMenu.enabled = !true;
    }


    // Quality of Life - unselect last option

    public void SelectionReset()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
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
