using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Menu Slots")]
    public GameObject MenuMain;
    public GameObject MenuOptions;
    public GameObject MenuCredits;
    public GameObject MenuConfirmExit;




    void Awake()
    {
        Switch_MainMenu();
    }


    void Update()
    {

    }

    public void Switch_MainMenu()
    {
        MenuMain.SetActive(true);
        MenuOptions.SetActive(false);
        MenuCredits.SetActive(false);
        MenuConfirmExit.SetActive(false);
    }

    public void Switch_Options()
    {
        MenuMain.SetActive(false);
        MenuOptions.SetActive(true);
    }

    public void Switch_Credits()
    {
        MenuMain.SetActive(false);
        MenuCredits.SetActive(true);
    }

    public void Switch_ConfirmExit()
    {
        MenuConfirmExit.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
