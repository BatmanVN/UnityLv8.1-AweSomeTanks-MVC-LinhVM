using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate<EnemyController>
{
    public void OnEnter(EnemyController enemy)
    {

    }

    public void OnExercute(EnemyController enemy)
    {
        if (enemy.Enemy != null)
        {
            enemy.ChangeState(new RunState());
        }
    }

    public void OnExit(EnemyController enemy)
    {
        
    }
}
