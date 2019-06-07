using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    //private GameObject _wpMenu, _wpStage;

    public void MovePlayerToStage(GameObject _wpStage)
    {
        _camera.transform.position = _wpStage.transform.position;
    }

    public void MovePlayerToMenu(GameObject _wpHome)
    {
        _camera.transform.position = _wpHome.transform.position;
    }
}
