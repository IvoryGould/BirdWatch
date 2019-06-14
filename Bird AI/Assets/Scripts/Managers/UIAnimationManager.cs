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

    public bool _fireCamera;

    public void Start()
    {
        _fireCamera = false;
        AnimatorPreviewImage = ObjPreviewImage.GetComponent<Animator>();
        AnimatorPreviewConfirm = ObjPreviewConfirm.GetComponent<Animator>();
    }

    public void PhotoAnim()
    {
        
        _fireCamera = true;
        AnimatorPreviewImage.SetBool("_fireCamera", _fireCamera);
        AnimatorPreviewConfirm.SetBool("_fireCamera", _fireCamera);
        Debug.Log("Photo Taken " + _fireCamera);
    }

    public void ResetAnimStates()
    {
        _fireCamera = false;
        AnimatorPreviewImage.SetBool("_fireCamera", _fireCamera);
        AnimatorPreviewConfirm.SetBool("_fireCamera", _fireCamera);
        Debug.Log("Photo Reverted " + _fireCamera);
    }
}
