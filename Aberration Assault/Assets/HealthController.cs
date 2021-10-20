using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] GameObject[] _hearts;
    int _healthIndex = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy") == true)
       {
            _hearts[_healthIndex].SetActive(false);
            _healthIndex++;
            if(_healthIndex > 2)
            {
                //GAME OVER
            }
       }
    }
}
