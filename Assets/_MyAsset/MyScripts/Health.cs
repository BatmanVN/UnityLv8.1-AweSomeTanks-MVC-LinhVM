using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float healthPoint;
    public UnityEvent<float,float> onHealthChangeValue;
    public UnityEvent onTakeDame;
    public UnityEvent onDie;
    public bool isDead => healthPoint <= 0;
    public float HealthPoint
    {
        get => healthPoint;
        set
        {
            healthPoint = value;
            onHealthChangeValue?.Invoke(healthPoint, MaxHealth);
        }
    }
    private void Start()
    {
        
    }
    public float MaxHealth { get => maxHealth;}

    private void Awake()
    {
        healthPoint = MaxHealth;
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
