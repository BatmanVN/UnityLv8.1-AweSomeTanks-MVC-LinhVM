using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectDestroy : MonoBehaviour
{
    [SerializeField] protected GameObject healthBar;
    [SerializeField] protected Health health;
    [SerializeField] protected Gun gun;
    [SerializeField] protected GameObject point;
    [SerializeField] protected GameObject effectExplosive;
    [SerializeField] protected float time;
}
