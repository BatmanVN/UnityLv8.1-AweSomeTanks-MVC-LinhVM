using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag(StringConst.wallParaname) 
            || bullet.CompareTag(StringConst.destroyParaname) 
            || bullet.CompareTag(StringConst.playerParaname))
        {
            this.gameObject.SetActive(false);
        }
    }
}
