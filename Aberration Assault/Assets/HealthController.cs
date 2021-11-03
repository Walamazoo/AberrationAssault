using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{

    [SerializeField] GameObject[] _hearts;
    int _healthIndex = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy") == true || collision.gameObject.CompareTag("Bullet") == true)
       {
            _hearts[_healthIndex].SetActive(false);
            _healthIndex++;
            if(_healthIndex > 2)
            {
                SceneManager.LoadScene(0);
            }
       }
    }
    /*
    void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") == true)
        {
            _hearts[_healthIndex].SetActive(false);
            _healthIndex++;
            if (_healthIndex > 2)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    */
}
