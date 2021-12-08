using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarActive : MonoBehaviour
{
    [SerializeField] GameObject _healthBar;

    void OnTriggerEnter2D()
    {
        _healthBar.SetActive(true);
    }
}
