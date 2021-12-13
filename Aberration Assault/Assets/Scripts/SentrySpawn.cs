using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentrySpawn : MonoBehaviour
{
    [SerializeField] GameObject _sentryPrefab;
    [SerializeField] GameObject _sentryReady;
    public bool _sentryAvailable = false;

    [SerializeField] bool _paused = false;

    public int _sentryBulletDamage = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space") && _paused == false && _sentryAvailable == true)
        {
            SpawnSentry();
            _sentryAvailable = false;
            _sentryReady.SetActive(false);
            Invoke("SentryAvailableRefresh", 15f);
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

    void SpawnSentry()
    {
        GameObject sentry = Instantiate(_sentryPrefab, transform.position, Quaternion.identity);
        sentry.GetComponent<SentryDrone>()._bulletDamage = _sentryBulletDamage;
    }

    void SentryAvailableRefresh()
    {
        _sentryAvailable = true;
        _sentryReady.SetActive(true);
    }
}
