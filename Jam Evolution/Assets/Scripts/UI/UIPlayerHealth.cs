using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] private Image _healthImage;
    private PlayerHealth _playerHealth;
    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {     
        _healthImage.fillAmount = (float)_playerHealth.CurrentHealth / _playerHealth.MaxHealth;
    }
}
