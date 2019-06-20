using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonOnMouseOver : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource SFXSource;

    public void Start()
    {
        SFXSource = GameManager.SFXSource;
    }

    public void OnPointerEnter(PointerEventData _eventData)
    {
        SFXSource.PlayOneShot(UIController._sFXHover);
    }
}
