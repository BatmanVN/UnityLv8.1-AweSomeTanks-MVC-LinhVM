//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class RunRandom : Istate<EnemyController>
//{
//    float time = 0f;
//    float countTime;
//    float timeRandom = 0f;
//    public void OnEnter(EnemyController enemy)
//    {
//        time = 6f;
//        countTime = 0f;
//        timeRandom = 2f;
//        enemy.RandomMove();
//    }

//    public void OnExercute(EnemyController enemy)
//    {
//        timeRandom -= Time.deltaTime;
//        countTime += Time.deltaTime;
//        if (timeRandom <= 0)
//        {
//            enemy.RandomMove();
//        }
//        if (enemy.isMoving)
//        {
//            enemy.ChangeState(new RunState());
//        }
//        if (countTime >= time && enemy.Target == null)
//        {
//            enemy.ChangeState(new IdleState());
//        }
//    }
//    public void OnExit(EnemyController enemy)
//    {

//    }
//}
