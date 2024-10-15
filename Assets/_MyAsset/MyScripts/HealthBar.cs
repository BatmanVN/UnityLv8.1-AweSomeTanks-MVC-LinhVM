using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health health;
    [SerializeField] protected Image healthValue;
    Transform cameraTransform;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cameraTransform.transform.rotation * - Vector3.forward, cameraTransform.transform.rotation * Vector3.up);
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        health.onHealthChangeValue.AddListener(UpdateHealthBar);
    }
    public void UpdateHealthBar(float healthPoint, float maxHealth)
    {
        healthValue.fillAmount = healthPoint / maxHealth;
    }
}
