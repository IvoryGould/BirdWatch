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

    GameManager GameManager;

    public bool _options = false;      // safety for slider functionality

    // HERE ARE THE FUNCTIONS FOR THE MAIN MENU

    public void Awake()
    {
        GameManager = GetComponent<GameManager>();
        _sFXEnter = Resources.Load("Foggysoft/FX51 - Select 1.wav") as AudioClip;
        _sFXLeave = Resources.Load("Foggysoft/FX51 - Select 2.wav") as AudioClip;
        _sFXSnap = Resources.Load("satanicupsman/Camera_Polaroid.wav") as AudioClip;
    }

    public void Main_Menu()           // Switch menus back to Main Menu + failsafe for loose UI panels. 
    {
        GameManager.SFXSource.PlayOneShot(_sFXLeave);

        MenuMain.SetActive(true);
        MenuOptions.SetActive(false);
        MenuCredits.SetActive(false);
        MenuConfirmExit.SetActive(false);
        _options = false;

        SelectionReset();
    }

    public void Main_Options()        // Switch to Options, Closes Main Menu Panel.
    {
        GameManager.SFXSource.PlayOneShot(_sFXEnter);
        MenuMain.SetActive(false);
        MenuOptions.SetActive(true);
        _options = true;

        SelectionReset();
    }

    public void Main_Credits()            // Switch to Credits, Closes Main Menu Panel.
    {
        GameManager.SFXSource.PlayOneShot(_sFXEnter);
        MenuMain.SetActive(false);
        MenuCredits.SetActive(true);

        SelectionReset();
    }

    public void Main_ConfirmExit()        // Opens Exit Confirm Panel.
    {
        GameManager.SFXSource.PlayOneShot(_sFXEnter);
        MenuConfirmExit.SetActive(true);

        SelectionReset();
    }

    // HERE ARE THE FUNCTIONS FOR THE PAUSE MENU

    public void Pause_Main()
    {
        GameManager.SFXSource.PlayOneShot(_sFXEnter);
        CvsPauseMenu.enabled = true;
        PauseMain.SetActive(true);
        PauseOptions.SetActive(false);
        PauseConfirmExit.SetActive(false);
        _options = false;

        SelectionReset();
    }

    public void Pause_Resume()
    {
        GameManager.SFXSource.PlayOneShot(_sFXLeave);

        PauseMain.SetActive(false);
        PauseOptions.SetActive(false);
        PauseConfirmExit.SetActive(false);
        CvsPauseMenu.enabled = false;

        SelectionReset();
    }

    public void Pause_Options()
    {
        GameManager.SFXSource.PlayOneShot(_sFXEnter);

        PauseMain.SetActive(false);
        PauseOptions.SetActive(true);
        _options = true;

        SelectionReset();
    }

    public void Pause_ConfirmExit()
    {
        GameManager.SFXSource.PlayOneShot(_sFXEnter);

        PauseConfirmExit.SetActive(true);

        SelectionReset();
    }

    public void Pause_ExitToMain()
    {
        GameManager.SFXSource.PlayOneShot(_sFXLeave);

        CvsPauseMenu.enabled = false;
        CvsMainMenu.enabled = true;

        SelectionReset();
    }



    // Quality of Life - unselect last option

    public void SelectionReset()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}
