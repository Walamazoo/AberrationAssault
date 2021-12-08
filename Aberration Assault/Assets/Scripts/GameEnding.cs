using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject _endWall;

    void FixedUpdate()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            _endWall.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            SceneManager.LoadScene("Win");
    }
}
