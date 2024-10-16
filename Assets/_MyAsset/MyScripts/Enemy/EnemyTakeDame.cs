using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDame : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag(StringConst.bulletPlayer))
        {
            enemyController.IsTakedDame = true;
        }
    }
}
