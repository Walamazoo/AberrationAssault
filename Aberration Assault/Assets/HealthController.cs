using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code for sprite color changing on lines 19 and 39 from https://stuartspixelgames.com/2019/02/19/how-to-change-sprites-colour-or-transparency-unity-c/

public class HealthController : MonoBehaviour
{

    [SerializeField] GameObject[] _hearts;
    int _healthIndex = 0;

    [SerializeField] SpriteRenderer _sprite;
    private Color _normalColor;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _normalColor = _sprite.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy") == true || collision.gameObject.CompareTag("Enemy Bullet") == true)
       {
            _hearts[_healthIndex].SetActive(false);
            _healthIndex++;
            StartCoroutine(damageFlash());
            if (_healthIndex > 2)
            {
                SceneManager.LoadScene(0);
            }
       }
    }

    IEnumerator damageFlash()
    {
        _sprite.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        _sprite.color = _normalColor;
    }
}
