using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag(StringConst.wallParaname) 
            || bullet.CompareTag(StringConst.destroyParaname) 
            || bullet.CompareTag(StringConst.baseParaname)
            || bullet.CompareTag(StringConst.enemyParaname))
        {
            this.gameObject.SetActive(false);
        }
    }
}
