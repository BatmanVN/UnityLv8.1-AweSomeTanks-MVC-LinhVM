using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCount : Singleton<TankCount>
{
    [SerializeField] private int count;
    [SerializeField] protected Text text;

    public int Count { get => count;}

    public void CheckTank()
    {
        count++;
        text.text = Count.ToString();
        Debug.Log(Count);
    }
    private void Update()
    {

    }
}
