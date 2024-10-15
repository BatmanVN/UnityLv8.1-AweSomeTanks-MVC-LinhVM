using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.CompareTag(StringConst.wallParaname) || bullet.gameObject.CompareTag(StringConst.destroyParaname) || bullet.gameObject.CompareTag(StringConst.baseParaname))
        {
            this.gameObject.SetActive(false);
        }
    }
}
