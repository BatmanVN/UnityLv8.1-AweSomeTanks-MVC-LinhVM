using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool isTouch;
    public bool IsTouch { get => isTouch; set => isTouch = value; }

    private void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.CompareTag(StringConst.wallParaname) || bullet.gameObject.CompareTag(StringConst.destroyParaname))
        {
            IsTouch = true;
            this.gameObject.SetActive(false);
        }
    }
}
