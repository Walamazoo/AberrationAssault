using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code for shooting created based on https://www.youtube.com/watch?v=LNLVOjbrQj4

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform _firePoint;
    [SerializeField] Transform _firePoint2;
    [SerializeField] Transform _firePoint3;
    [SerializeField] GameObject _bulletprefab;

    [SerializeField] float _bulletForce = 20f;

    [SerializeField] bool _paused = false;

    public int _bulletDamage = 2;

    public bool _spread = false;

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
        bullet.GetComponent<Bullet>()._damage = _bulletDamage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
        if (_spread == true)
        {
            GameObject bullet1 = Instantiate(_bulletprefab, _firePoint2.position, _firePoint2.rotation);
            bullet1.GetComponent<Bullet>()._damage = _bulletDamage;
            bullet1.GetComponent<Rigidbody2D>().AddForce(_firePoint2.up * _bulletForce, ForceMode2D.Impulse);

            GameObject bullet2 = Instantiate(_bulletprefab, _firePoint3.position, _firePoint3.rotation);
            bullet2.GetComponent<Bullet>()._damage = _bulletDamage;
            bullet2.GetComponent<Rigidbody2D>().AddForce(_firePoint3.up * _bulletForce, ForceMode2D.Impulse);
        }
    }
}
