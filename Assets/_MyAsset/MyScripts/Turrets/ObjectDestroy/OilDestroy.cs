using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilDestroy : ObjectDestroy
{
    [SerializeField] private float radiusExplosion;
    [SerializeField] protected float dameExplosive;
    private Coroutine bar;
    private bool beAttack;
    private void OnCollisionEnter(Collision oil)
    {
        if (oil.gameObject.CompareTag(StringConst.bulletParaname))
        {
            healthBar.SetActive(true);
            beAttack = true;
        }
    }
    private void OnCollisionExit(Collision oil)
    {
        if (oil.gameObject.CompareTag(StringConst.bulletParaname))
        {
            bar = StartCoroutine(DeActiveBar());
        }
    }
    private void TakeDame()
    {
        if (beAttack)
        {
            health.TakeDame(gun.Dame);
            beAttack = false;
        }
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
            health.TakeDame(dameExplosive);
        }
    }
    private IEnumerator DeActiveBar()
    {
        yield return new WaitForSeconds(time);
        healthBar.SetActive(false);
        StopCoroutine(bar);
    }
    private void Update()
    {
        TakeDame();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point.transform.position, radiusExplosion);
    }
}
