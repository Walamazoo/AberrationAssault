using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(1);
    }
}
