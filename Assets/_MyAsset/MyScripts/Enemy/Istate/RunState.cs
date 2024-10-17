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
        if (enemy.isDetected || enemy.isTakedDame)
        {
            if (enemy.Enemy != null)
            {
                enemy.MoveToPoint(enemy.Enemy.transform.position);
                enemy.Attack();
            }
            else
            {
                enemy.ChangeState(new IdleState());
            }
        }
    }

    public void OnExit(EnemyController enemy)
    {

    }
}
