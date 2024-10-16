using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDestroy : ObjectDestroy
{
    [SerializeField] protected HealthBar barHealth;
    private Coroutine bar;
    private bool beAttack;

    private void OnTriggerEnter(Collider oil)
    {
        if (oil.CompareTag(StringConst.bulletPlayer))
        {
            healthBar.SetActive(true);
            beAttack = true;
        }
    }
    private void TakeDame()
    {
        if (beAttack)
        {
            health.TakeDame(gun.Dame);
            beAttack = false;
            bar = StartCoroutine(DeActiveBar());
            barHealth.UpdateHealthBar(health.HealthPoint,health.MaxHealth);
        }
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
}
