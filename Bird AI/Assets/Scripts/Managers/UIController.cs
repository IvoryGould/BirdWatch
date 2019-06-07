using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Menu Slots")]
    public GameObject MenuMain;
    public GameObject MenuOptions;
    public GameObject MenuCredits;
    public GameObject MenuConfirmExit;

    /*
    [Header("Options Text Slots")]
    public GameObject VolMaster;
    public GameObject VolMusic;
    public GameObject VolSound;

    
    [Header("Options Sliders")]
    public Slider SldVolMaster;
    public Slider SldVolMusic;
    public Slider SldVolSound;

    private Text SldVolMaster_Val, SldVolMusic_Val, SldVolSound_Val;
    private TextMeshPro _textVolMaster, _textVolMusic, _textVolSound;
    */

    private bool _options;

    public UnityEvent EventController;
    

    void Awake()
    {
        EventController.Invoke();
        Switch_MainMenu();
        //TextHook();
    }


    void Update()
    {
        if (_options == true)
        {
            SliderFeedback();
        }
    }

    /*
    private void TextHook()                  // Workaround for Text mesh pro with slider feedback.
    {
        _textVolMaster = VolMaster.GetComponent<TextMeshPro>();
        _textVolMusic = VolMusic.GetComponent<TextMeshPro>();
        _textVolSound = VolSound.GetComponent<TextMeshPro>();
    }
    */

    public void SliderFeedback()
    {
        _textVolMaster.text = SldVolMaster.value.ToString();
        _textVolMusic.text = SldVolMusic.value.ToString();
        _textVolSound.text = SldVolSound.value.ToString();
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
