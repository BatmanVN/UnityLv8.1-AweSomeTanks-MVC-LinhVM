using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthBar;
    private void Start()
    {
        health.onHealthChangeValue.AddListener(UpdateHealthBar);
    }

    private void UpdateHealthBar(float healthPoint, float maxHealth)
    {
        healthBar.fillAmount = healthPoint / maxHealth;
    }
}
