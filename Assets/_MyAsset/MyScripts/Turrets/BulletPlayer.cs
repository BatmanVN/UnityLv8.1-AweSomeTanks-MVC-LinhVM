using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private float dame;
    [SerializeField] private GameObject effect;
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag(StringConst.wallParaname)
            || bullet.CompareTag(StringConst.destroyParaname)
            || bullet.CompareTag(StringConst.baseParaname)
            || bullet.CompareTag(StringConst.enemyParaname))
        {
            effect.SetActive(true);
            health = bullet.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDame(dame);
            }
            Invoke(nameof(DeActive), 0.15f);
        }
    }

    public void DeActive()
    {
        effect.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
