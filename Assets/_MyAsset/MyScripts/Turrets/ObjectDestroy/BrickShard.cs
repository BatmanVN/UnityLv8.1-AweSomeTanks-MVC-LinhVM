using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickShard : MonoBehaviour
{
    [SerializeField] private GameObject wallEffect;
    [SerializeField] private Transform wallPoint;


    public void Destroy()
    {
        HitSurface hitSurface = this.gameObject.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(wallPoint.position);
                wallEffect = Instantiate(effectPrefab, wallPoint.position, effectRotation);
            }
        }
        Destroy(this.gameObject);
        Destroy(wallEffect, 1.5f);
    }
}
