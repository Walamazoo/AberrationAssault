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
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadBossLevel()
    {
        SceneManager.LoadScene("Boss Level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
