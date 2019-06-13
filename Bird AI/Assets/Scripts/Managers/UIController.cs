using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIController : MonoBehaviour
{
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

    private bool _options = false;


    void Awake()
    {
        //EventController.Invoke();
        Switch_MainMenu();
        Switch_Resume();
        CvsMainMenu.enabled = true;
        CvsPauseMenu.enabled = false;
    }

    /// <summary>
    /// 
    /// HERE ARE THE FUNCTIONS FOR THE MAIN MENU
    /// 
    /// </summary>

    public void Switch_MainMenu()           // Switch menus back to Main Menu + failsafe for loose UI panels. 
    {
        MenuMain.SetActive(true);
        MenuOptions.SetActive(false);
        MenuCredits.SetActive(false);
        MenuConfirmExit.SetActive(false);
        _options = false;
    }

    public void Switch_MainOptions()        // Switch to Options, Closes Main Menu Panel.
    {
        MenuMain.SetActive(false);
        MenuOptions.SetActive(true);
        _options = true;
    }

    public void Switch_Credits()            // Switch to Credits, Closes Main Menu Panel.
    {
        MenuMain.SetActive(false);
        MenuCredits.SetActive(true);
    }

    public void Switch_ConfirmExit()        // Opens Exit Confirm Panel.
    {
        MenuConfirmExit.SetActive(true);
    }

    /// <summary>
    ///  
    /// HERE ARE THE FUNCTIONS FOR THE PAUSE MENU
    /// 
    /// </summary>

    public void Switch_Resume()
    {
        PauseMain.SetActive(false);
        PauseOptions.SetActive(false);
        PauseConfirmExit.SetActive(false);
    }

    public void Switch_PauseOptions()
    {
        PauseMain.SetActive(false);
        PauseOptions.SetActive(true);
    }

    public void Switch_PauseConfirmExit()
    {
        PauseMain.SetActive(false);
        PauseOptions.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        CvsMainMenu.enabled = false;
        CvsPauseMenu.enabled = true;

    }
}
