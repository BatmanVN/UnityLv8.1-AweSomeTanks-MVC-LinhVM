using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] private float healthPoint;
    public UnityEvent<float,float> onHealthChangeValue;
    public UnityEvent onTakeDame;
    public UnityEvent onDie;
    public bool isDead => healthPoint <= 0;
    protected float HealthPoint
    {
        get => healthPoint;
        set
        {
            healthPoint = value;
            onHealthChangeValue?.Invoke(healthPoint, maxHealth);
        }
    }
    private void Awake()
    {
        healthPoint = maxHealth;
    }
    public void TakeDame(float dame)
    {
        if (isDead) return;
        HealthPoint -= dame;
        onTakeDame?.Invoke();
        if (isDead)
        {
            Dead();
        }
    }
    protected virtual void Dead()
    {
        onDie?.Invoke();
    }
}
