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
    //public Canvas CvsPause;
    public GameObject mainMenuGameObject;

    [Header("Menu Slots")]
    public GameObject MenuMain;
    public GameObject MenuOptions;
    public GameObject MenuCredits;
    public GameObject MenuConfirmExit;

    //public UnityEvent EventController;

    private bool _options = false;


    void Awake()
    {
        //EventController.Invoke();
        Switch_MainMenu();
        //CvsPause.enabled = false;

    }


    void Update()
    {



    }


    public void Switch_MainMenu()           // Switch menus back to Main Menu + failsafe for loose UI panels. 
    {
        MenuMain.SetActive(true);
        MenuOptions.SetActive(false);
        MenuCredits.SetActive(false);
        MenuConfirmExit.SetActive(false);

        _options = false;
    }

    public void Switch_Options()            // Switch to Options, Closes Main Menu Panel.
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

    public void QuitGame()                  // Cancels Editor Playtest or Closes application. :)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
