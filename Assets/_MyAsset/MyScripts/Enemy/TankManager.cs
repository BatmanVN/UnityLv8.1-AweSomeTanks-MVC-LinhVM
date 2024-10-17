using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankManager : Singleton<TankManager>
{
    [SerializeField] private List<GameObject> tanks;

    public List<GameObject> Tanks { get => tanks;}
    public void AddTank(GameObject enemy)
    {
        tanks.Add(enemy);
    }
    //public void CheckTanks()
    //{
    //    for(int i = 0; i< tanks.Count; i++)
    //    {
    //        if (tanks[i] == null)
    //        {
    //            tanks.RemoveAt(i);
    //            TankCount.Instance.CheckTank();
    //        }
    //    }
    //}
    private void Update()
    {
        //CheckTanks();
    }
}
