using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderToText : MonoBehaviour
{
    [Header("Slider")]
    public Slider Slider;

    private TextMeshProUGUI _sliderText;

    void Start()
    {
        _sliderText = GetComponent<TextMeshProUGUI>();
        ShowSliderValue();
    }

    void Update()
    {
        
    }
    
    public void ShowSliderValue()
    {
        //Debug.Log(Slider.value);
        string _sliderMessage = Slider.value.ToString();
        _sliderText.text = _sliderMessage;
    }
    
}