using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     
    public GameObject Camera;
    //private GameObject _wpMenu, _wpStage;

    public void MovePlayerToStage(GameObject _wpStage)
    {
        Camera.transform.rotation = _wpStage.transform.rotation;
    }

    public void MovePlayerToMenu(GameObject _wpHome)
    {
        Camera.transform.position = _wpHome.transform.position;
    }
}
