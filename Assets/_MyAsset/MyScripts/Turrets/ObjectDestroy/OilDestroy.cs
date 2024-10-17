using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilDestroy : ObjectDestroy
{
    [SerializeField] private float radiusExplosion;
    [SerializeField] protected float dameExplosive;
    private void Start()
    {

    }
    public void EnableHealthBar()
    {
        healthBar.SetActive(true);
        healthBar.GetComponent<HealthBar>().UpdateHealthBar(health.HealthPoint, health.MaxHealth);
    }
    public void Destroy()
    {
        InstanceEffect();
        Collider[] affectedObj = Physics.OverlapSphere(point.transform.position, radiusExplosion);
        for (int i = 0; i < affectedObj.Length; i++)
        {
            DeliverDame(affectedObj[i]);
        }
        Destroy(this.gameObject);
        Destroy(effectExplosive, 1.5f);
    }
    private void InstanceEffect()
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
    }
    private void DeliverDame(Collider victim)
    {
        Health health = victim.GetComponent<Health>();
        if (health != null)
        {
            if (victim.gameObject.CompareTag(StringConst.playerParaname))
            {
                dameExplosive = 15f;
            }
            if (victim.gameObject.CompareTag(StringConst.destroyParaname))
            {
                dameExplosive = 50f;
            }
            if (victim.gameObject.CompareTag(StringConst.enemyParaname))
            {
                dameExplosive = 25f;
            }
            health.TakeDame(dameExplosive);
        }
    }
    private void Update()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point.transform.position, radiusExplosion);
    }
}
