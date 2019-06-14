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



    public bool _options = false;      // safety for slider functionality

    // HERE ARE THE FUNCTIONS FOR THE MAIN MENU

    public void Main_Menu()           // Switch menus back to Main Menu + failsafe for loose UI panels. 
    {
        MenuMain.SetActive(true);
        MenuOptions.SetActive(false);
        MenuCredits.SetActive(false);
        MenuConfirmExit.SetActive(false);
        _options = false;

        SelectionReset();
    }

    public void Main_Options()        // Switch to Options, Closes Main Menu Panel.
    {
        MenuMain.SetActive(false);
        MenuOptions.SetActive(true);
        _options = true;

        SelectionReset();
    }

    public void Main_Credits()            // Switch to Credits, Closes Main Menu Panel.
    {
        MenuMain.SetActive(false);
        MenuCredits.SetActive(true);

        SelectionReset();
    }

    public void Main_ConfirmExit()        // Opens Exit Confirm Panel.
    {
        MenuConfirmExit.SetActive(true);

        SelectionReset();
    }

    // HERE ARE THE FUNCTIONS FOR THE PAUSE MENU

    public void Pause_Main()
    {
        CvsPauseMenu.enabled = true;
        PauseMain.SetActive(true);
        PauseOptions.SetActive(false);
        PauseConfirmExit.SetActive(false);
        _options = false;

        SelectionReset();
    }

    public void Pause_Resume()
    {
        PauseMain.SetActive(false);
        PauseOptions.SetActive(false);
        PauseConfirmExit.SetActive(false);
        CvsPauseMenu.enabled = false;

        SelectionReset();
    }

    public void Pause_Options()
    {
        PauseMain.SetActive(false);
        PauseOptions.SetActive(true);
        _options = true;

        SelectionReset();
    }

    public void Pause_ConfirmExit()
    {
        PauseConfirmExit.SetActive(true);

        SelectionReset();
    }

    public void Pause_ExitToMain()
    {
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
