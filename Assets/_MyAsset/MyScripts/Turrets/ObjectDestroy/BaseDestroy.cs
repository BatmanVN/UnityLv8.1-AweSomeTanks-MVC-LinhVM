using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDestroy : ObjectDestroy
{
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
