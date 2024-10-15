using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Health health;
    [SerializeField] private Gun gun;
    [SerializeField] private GameObject effectExplosive;
    [SerializeField] private Transform pointExplo;
    [SerializeField] private float radiusExplosion;
    [SerializeField] protected float time;
    [SerializeField] protected float dameExplosive;
    private Coroutine bar;
    private bool beAttack;
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag(StringConst.bulletParaname))
        {
            healthBar.SetActive(true);
            beAttack = true;
        }
    }
    private void OnCollisionExit(Collision obj)
    {
        if (obj.gameObject.CompareTag(StringConst.bulletParaname))
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
        GameObject explosive =  Instantiate(effectExplosive, pointExplo.position, Quaternion.identity);
        Collider[] affectedObj = Physics.OverlapSphere(pointExplo.position, radiusExplosion);
        for (int i = 0; i < affectedObj.Length; i++)
        {
            DeliverDame(affectedObj[i]);
        }
        Destroy(this.gameObject);
        Destroy(explosive, 1.5f);
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
        Gizmos.DrawWireSphere(pointExplo.position, radiusExplosion);
    }
}
