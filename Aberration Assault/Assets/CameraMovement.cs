using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _player;

    void FixedUpdate()
    {
        float xPos = _player.transform.position.x;
        float yPos = _player.transform.position.y;
        Vector3 newPos = new Vector3(xPos, yPos, -10);
        gameObject.transform.position = newPos;
    }
}
