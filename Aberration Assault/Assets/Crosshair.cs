using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    [SerializeField] Camera _cam;

    void Update()
    {
        gameObject.transform.position = _cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
