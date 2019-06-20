using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SliderToText : MonoBehaviour//, IPointerEnterHandler
{
    [Header("Slider")]
    public Slider Slider;

    UIController UIController;
    
    private AudioSource SFXSource;

    private TextMeshProUGUI _sliderText;

    void Awake()
    {
        SFXSource = GameManager.SFXSource;
        UIController = GameObject.Find("GAME MANAGEMENT").GetComponent<UIController>();
        _sliderText = GetComponent<TextMeshProUGUI>();
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string _sliderMessage = Slider.value.ToString();
        _sliderText.text = _sliderMessage;
    }
    /*
    public void OnPointerEnter(PointerEventData _eventData)
    {
        SFXSource.PlayOneShot(UIController._sFXHover);
    }
    */
}