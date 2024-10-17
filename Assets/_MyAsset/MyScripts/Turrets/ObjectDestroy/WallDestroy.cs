using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : ObjectDestroy
{
    public void EnableHealthBar()
    {
        healthBar.SetActive(true);
        healthBar.GetComponent<HealthBar>().UpdateHealthBar(health.HealthPoint, health.MaxHealth);
    }
    public void Destroy()
    {
        HitSurface hitSurface = this.gameObject.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(point.transform.position);
                effectExplosive = Instantiate(effectPrefab, point.transform.position, effectRotation);
            }
        }
        Destroy(this.gameObject);
        Destroy(effectExplosive, 1.5f);
    }
    private void Update()
    {

    }
}
