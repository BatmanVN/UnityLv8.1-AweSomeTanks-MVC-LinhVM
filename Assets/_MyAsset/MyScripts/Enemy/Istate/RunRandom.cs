using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunRandom : Istate<EnemyController>
{
    float time = 0f;
    float countTime;
    public void OnEnter(EnemyController enemy)
    {
        time = 3f;
        countTime = 0f;
        //enemy.SetRandomPostion(enemy.radiusRandom);
        enemy.MoveRandom();
    }

    public void OnExercute(EnemyController enemy)
    {
        countTime += Time.deltaTime;
        if (enemy.Enemy != null || enemy.isDetected)
        {
            enemy.ChangeState(new RunState());
        }
        if (countTime >= time && enemy.Enemy == null)
        {
            enemy.ChangeState(new IdleState());
        }
    }
    public void OnExit(EnemyController enemy)
    {

    }
}
