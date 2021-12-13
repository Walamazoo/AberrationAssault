using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;

    [SerializeField] bool _isPaused = false;

    [SerializeField] MaterialController _materialController;

    [SerializeField] Shooting _shooting;

    [SerializeField] int _laserUpgradeCost;
    [SerializeField] TextMeshProUGUI _laserUpgradeCostDisplay;
    [SerializeField] GameObject[] _laserUpgrades;
    int _laserUpgradeIndex = 0;

    [SerializeField] int _spreadCost;
    [SerializeField] TextMeshProUGUI _spreadUpgradeCostDisplay;
    [SerializeField] GameObject _spreadAquired;
    bool _gotSpread = false;

    [SerializeField] DroneMovement _drone;
    [SerializeField] int _droneUpgradeCost;
    [SerializeField] TextMeshProUGUI _droneUpgradeCostDisplay;
    [SerializeField] GameObject[] _droneUpgrades;
    int _droneUpgradeIndex = 0;

    [SerializeField] HealthController _shieldControl;

    [SerializeField] int _shieldCost;
    [SerializeField] TextMeshProUGUI _shieldUpgradeCostDisplay;
    [SerializeField] GameObject _shieldAquired;
    bool _gotShield = false;

    [SerializeField] int _sentryCost;
    [SerializeField] TextMeshProUGUI _getSentryUpgradeCostDisplay;
    [SerializeField] GameObject _sentryAquired;
    bool _gotSentry = false;

    [SerializeField] GameObject _sentryReady;
    [SerializeField] GameObject _sentryUpgradeMenu;

    [SerializeField] SentrySpawn _sentry;
    [SerializeField] int _sentryUpgradeCost;
    [SerializeField] TextMeshProUGUI _sentryUpgradeCostDisplay;
    [SerializeField] GameObject[] _sentryUpgrades;
    int _sentryUpgradeIndex = 0;

    void Start()
    {
        _laserUpgradeCostDisplay.text = _laserUpgradeCost.ToString();
        _droneUpgradeCostDisplay.text = _droneUpgradeCost.ToString();

        _pauseMenu.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (_isPaused == false)
            {
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);
                _isPaused = true;
            }
            else
            {
                _pauseMenu.SetActive(false);
                Time.timeScale = 1;
                _isPaused = false;
            } 
        }
    }

    public void UpgradeLaser()
    {
        if (_laserUpgradeIndex <= 2)
        {
            if (_materialController._materialAmount >= _laserUpgradeCost)
            {
                _materialController.UpdateMaterialAmount(-_laserUpgradeCost);
                _laserUpgradeCost += 2;
                _laserUpgradeCostDisplay.text = (_laserUpgradeCost).ToString();
                _laserUpgrades[_laserUpgradeIndex].GetComponent<Image>().color = new Color(12, 156, 229, 1);
                _laserUpgradeIndex += 1;
                if (_laserUpgradeIndex > 2)
                {
                    _laserUpgradeCostDisplay.text = "";
                }
                _shooting._bulletDamage += 2;
            }
        }
    }

    public void UpgradeDrone()
    {
        if (_droneUpgradeIndex <= 2)
        {
            if (_materialController._materialAmount >= _droneUpgradeCost)
            {
                _materialController.UpdateMaterialAmount(-_droneUpgradeCost);
                _droneUpgradeCost += 3;
                _droneUpgradeCostDisplay.text = (_droneUpgradeCost).ToString();
                _droneUpgrades[_droneUpgradeIndex].GetComponent<Image>().color = new Color(12, 156, 229, 1);
                _droneUpgradeIndex += 1;
                if (_droneUpgradeIndex > 2)
                {
                    _droneUpgradeCostDisplay.text = "";
                }
                _drone._droneDamage += 4;
            }
        }
    }

    public void GetSpread()
    {
        if (_gotSpread == false && _materialController._materialAmount >= _spreadCost)
        {
            _materialController.UpdateMaterialAmount(-_spreadCost);
            _spreadUpgradeCostDisplay.text = "";
            _spreadAquired.GetComponent<Image>().color = new Color(12, 156, 229, 1);
            _gotSpread = true;
            _shooting._spread = true;
        }
    }

    public void GetShield()
    {
        if (_gotShield == false && _materialController._materialAmount >= _shieldCost)
        {
            _materialController.UpdateMaterialAmount(-_shieldCost);
            _shieldUpgradeCostDisplay.text = "";
            _shieldAquired.GetComponent<Image>().color = new Color(12, 156, 229, 1);
            _gotShield = true;
            _shieldControl._shieldBought = true;
            _shieldControl.RechargeShield();
        }
    }

    public void GetSentry()
    {
        if (_gotSentry == false && _materialController._materialAmount >= _sentryCost)
        {
            _materialController.UpdateMaterialAmount(-_sentryCost);
            _getSentryUpgradeCostDisplay.text = "";
            _sentryAquired.GetComponent<Image>().color = new Color(12, 156, 229, 1);
            _gotSentry = true;
            _sentryUpgradeMenu.SetActive(true);
            _sentryReady.SetActive(true);
            _sentry._sentryAvailable = true;
        }
    }

    public void UpgradeSentry()
    {
        if (_sentryUpgradeIndex <= 2)
        {
            if (_materialController._materialAmount >= _sentryUpgradeCost)
            {
                _materialController.UpdateMaterialAmount(-_sentryUpgradeCost);
                _sentryUpgradeCost += 2;
                _sentryUpgradeCostDisplay.text = (_sentryUpgradeCost).ToString();
                _sentryUpgrades[_sentryUpgradeIndex].GetComponent<Image>().color = new Color(12, 156, 229, 1);
                _sentryUpgradeIndex += 1;
                if (_sentryUpgradeIndex > 2)
                {
                    _sentryUpgradeCostDisplay.text = "";
                }
                _sentry._sentryBulletDamage += 3;
            }
        }
    }
}
