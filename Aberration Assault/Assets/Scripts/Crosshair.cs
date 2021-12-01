using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] bool _paused = false;

    void Update()
    {
        if (_paused == false)
        {
            gameObject.transform.position = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9));
        }

        if (Input.GetKeyUp("escape"))
        {
            if (_paused == false)
            {
                _paused = true;
            }
            else
            {
                _paused = false;
            }
        }
        
    }
}
