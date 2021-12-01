using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;

    [SerializeField] bool _isPaused = false;

    void Start()
    {
        _pauseMenu.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (_isPaused == false)
            {
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);
                _isPaused = true;
            }
            else
            {
                _pauseMenu.SetActive(false);
                Time.timeScale = 1;
                _isPaused = false;
            } 
        }
    }
}
