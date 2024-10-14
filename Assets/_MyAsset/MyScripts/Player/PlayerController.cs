using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseTank
{
    [SerializeField] private TankMove moveControl;

    private void Start()
    {
        
    }
    private void Update()
    {
        PlayerMove();
    }
    protected void PlayerMove()
    {
        moveControl.MoveControl();
    }
}
