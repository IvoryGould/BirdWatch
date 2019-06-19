using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnMouseOver : MonoBehaviour
{
    public static AudioClip _sFXHover;
    public AudioSource SFXSource;

    public void Awake()
    {
        _sFXHover = Resources.Load("Foggysoft/FX50.wav") as AudioClip;
        SFXSource = GameObject.Find("CAM_Main").GetComponent<AudioSource>();
    }

    public void OnMouseOver()
    {
        SFXSource.PlayOneShot(_sFXHover);
    }
}
