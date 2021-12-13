using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryDrone : MonoBehaviour
{
    [SerializeField] float _firerate;
    [SerializeField] float _fireDistance;
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject _bulletprefab;
    public int _bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, _firerate);
        Invoke("Despawn", 10f);
    }

    void Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            var closestEnemy = enemies[0];
            var distance = Vector2.Distance(transform.position, enemies[0].transform.position);
            for (int i=0;i<enemies.Length;i++)
            {
                if (Vector2.Distance(transform.position, enemies[i].transform.position) < distance)
                {
                    closestEnemy = enemies[i];
                }
            }
            if (Vector2.Distance(transform.position, closestEnemy.transform.position) < _fireDistance)
            {
                GameObject bullet = Instantiate(_bulletprefab, _firePoint.position, Quaternion.identity);
                bullet.GetComponent<SentryBullet>()._damage = _bulletDamage;
                bullet.GetComponent<SentryBullet>()._enemy = closestEnemy.transform;
            }
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
