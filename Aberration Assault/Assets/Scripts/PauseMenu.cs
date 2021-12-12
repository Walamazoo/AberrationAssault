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

    void Start()
    {
        _laserUpgradeCost = 2;
        _laserUpgradeCostDisplay.text = _laserUpgradeCost.ToString();

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
                _laserUpgrades[_laserUpgradeIndex].GetComponent<Image>().color = new Color(12, 156, 229, 255);
                _laserUpgradeIndex += 2;
                if (_laserUpgradeIndex > 2)
                {
                    _laserUpgradeCostDisplay.text = "";
                }
                _shooting._bulletDamage += 1;
            }
        }
    }
}
