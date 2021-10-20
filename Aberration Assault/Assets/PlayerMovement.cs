using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code created based on https://www.youtube.com/watch?v=LNLVOjbrQj4

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] Rigidbody2D _rb;
    Vector2 _movement;
  
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }
    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }
}
