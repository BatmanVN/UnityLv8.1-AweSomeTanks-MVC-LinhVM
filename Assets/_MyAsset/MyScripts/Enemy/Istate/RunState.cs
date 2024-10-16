using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : Istate<EnemyController>
{
    public void OnEnter(EnemyController enemy)
    {

    }

    public void OnExercute(EnemyController enemy)
    {
        if (enemy.Enemy != null && enemy.isDetected)
        {
            enemy.MoveToPoint(enemy.Enemy.transform.position);
            enemy.Attack();
        }
    }

    public void OnExit(EnemyController enemy)
    {

    }
}
