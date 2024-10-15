using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
public class Gun : MonoBehaviour
{
    [SerializeField] protected LeanGameObjectPool bulletPool;
    [SerializeField] protected Transform pointBulletAppear;
    [SerializeField] private float dame;
    [SerializeField] protected float speedBullet;
    [SerializeField] protected float rpm;
    [SerializeField] protected float timeDisable;
    [SerializeField] private bool isLockedValue;

    public bool IsLockedValue
    {
        get => isLockedValue;
        set
        {
            isLockedValue = value;
            enabled = !isLockedValue;
        }
    }

    public float Dame { get => dame; set => dame = value; }
}
