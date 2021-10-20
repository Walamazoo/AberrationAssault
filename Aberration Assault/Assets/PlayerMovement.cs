using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for moving and aiming created based on https://www.youtube.com/watch?v=LNLVOjbrQj4

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Camera _cam;

    Vector2 _movement;
    Vector2 _mousePos;
  
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }
}
