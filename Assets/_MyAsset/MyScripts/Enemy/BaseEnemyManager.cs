//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class BaseEnemyManager : MonoBehaviour
//{
//    [SerializeField] protected List<GameObject> bases;
//    public UnityEvent onCheckBase;

//    public void CheckTanks()
//    {
//        foreach (GameObject baseSpawn in bases)
//        {
//            if (baseSpawn == null) return;
//            if (baseSpawn.GetComponent<Health>().isDead)
//            {
//                onCheckBase?.Invoke();
//                bases.Remove(baseSpawn);
//            }
//        }
//    }
//    private void Update()
//    {
//        CheckTanks();
//    }
//}
