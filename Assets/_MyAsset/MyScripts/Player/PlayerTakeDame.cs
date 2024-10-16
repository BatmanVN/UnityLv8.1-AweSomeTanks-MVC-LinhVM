using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDame : MonoBehaviour
{
    public bool isAttacked;
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag(StringConst.bulletParaname))
        {
                isAttacked = true;
        }
    }
}
