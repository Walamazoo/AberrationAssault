using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//material sprites from https://opengameart.org/content/top-down-2d-metal-box and https://opengameart.org/content/resouces-pack-1 

public class MaterialController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _materials;
    public int _materialAmount = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Material") == true)
        {
                Destroy(collision.gameObject);
                UpdateMaterialAmount(1);
        }
    }

    public void UpdateMaterialAmount(int amount)
    {
        _materialAmount += amount;
        _materials.text = "Materials: " + _materialAmount;
    }
}
