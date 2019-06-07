using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Player Locations")]
    [SerializeField]
        private GameObject _wpHome;
    [SerializeField]
        private GameObject _wpStage;
    
    public static bool _isPlaying;

    void Awake()
    {
        _isPlaying = false;
    }
    
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("FAKESTART GAME");
    }
}
