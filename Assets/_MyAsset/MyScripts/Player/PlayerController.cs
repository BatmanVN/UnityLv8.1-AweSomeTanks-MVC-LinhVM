using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseTank
{
    [SerializeField] private TankMove moveControl;
    [SerializeField] private TurreDefault shotControl;
    [SerializeField] private GameObject baseTank;
    [SerializeField] private GameObject turretTank;
    private void Start()
    {

    }
    private void Update()
    {
        PlayerMove();
        PlayerShot();
    }
    protected void PlayerMove()
    {
        moveControl.MoveControl();
        if (moveControl.MoveDirection != Vector3.zero)
        {
            Rotate(moveControl.MoveDirection, baseTank);
        }
        else
        {
            baseTank.transform.rotation = baseTank.transform.rotation;
        }
    }
    protected void PlayerShot()
    {
        shotControl.ShotTurret();
        if (shotControl.Target != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(shotControl.Target);
            turretTank.transform.rotation = Quaternion.Slerp(turretTank.transform.rotation, targetRotation, rotateTurretSpeed * Time.deltaTime);
        }
        else
        {
            turretTank.transform.rotation = turretTank.transform.rotation;
        }
    }
}
