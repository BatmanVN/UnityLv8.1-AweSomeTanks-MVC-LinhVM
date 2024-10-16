using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate<EnemyController>
{
    float time = 0f;
    float countTime;
    public void OnEnter(EnemyController enemy)
    {
        time = 2f;
        countTime = 0f;
    }

    public void OnExercute(EnemyController enemy)
    {
        countTime += Time.deltaTime;
        if (countTime >= time && enemy.Enemy == null)
        {
            enemy.ChangeState(new RunRandom());
        }
        if (enemy.Enemy != null)
        {
            enemy.ChangeState(new RunState());
        }
    }

    public void OnExit(EnemyController enemy)
    {
        
    }
}
