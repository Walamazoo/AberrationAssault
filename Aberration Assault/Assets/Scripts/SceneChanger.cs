using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
