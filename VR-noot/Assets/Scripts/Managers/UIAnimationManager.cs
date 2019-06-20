using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [Header("Animation Controllers")]
    public GameObject ObjPreviewImage;
    public GameObject ObjPreviewConfirm;

    private Animator AnimatorPreviewImage;
    private Animator AnimatorPreviewConfirm;


    GameManager GameManager;
    UIController UIController;

    public bool _fireCamera;

    public void Awake()
    {
        _fireCamera = !true;

        GameManager = GetComponent<GameManager>();
        UIController= GetComponent<UIController>();

        UIController = GetComponent<UIController>();
        AnimatorPreviewImage = ObjPreviewImage.GetComponent<Animator>();
        AnimatorPreviewConfirm = ObjPreviewConfirm.GetComponent<Animator>();
    }

    public void Start()
    {
        
    }

    public void TakePhoto()
    {
        _fireCamera = true;
        AnimatorPreviewImage.SetBool("_fireCamera", _fireCamera);
        AnimatorPreviewConfirm.SetBool("_fireCamera", _fireCamera);
        
    }

    public void PhotoAccept()
    {
        _fireCamera = !true;

        AnimatorPreviewImage.SetBool("_fireCamera", _fireCamera);
        AnimatorPreviewConfirm.SetBool("_fireCamera", _fireCamera);
        Debug.Log("Photo Reverted " + !_fireCamera);

        UIController.SelectionReset();
    }
}
