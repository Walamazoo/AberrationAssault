using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for shooting created based on https://www.youtube.com/watch?v=LNLVOjbrQj4

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject _bulletprefab;

    [SerializeField] float _bulletForce = 20f;

    [SerializeField] bool _paused = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _paused == false)
        {
            Shoot();
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

    void Shoot()
    {
        GameObject bullet = Instantiate(_bulletprefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
