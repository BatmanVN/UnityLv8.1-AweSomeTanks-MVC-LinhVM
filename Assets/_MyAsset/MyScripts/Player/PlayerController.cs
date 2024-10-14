using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseTank
{
    [SerializeField] private TankMove moveControl;
    [SerializeField] private TankShot shotControl;
    [SerializeField] private GameObject baseTank;
    [SerializeField] private GameObject turretTank;
    private Transform currentTransformTurret;
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
        Rotate(moveControl.MoveDirection, baseTank);
    }
    protected void PlayerShot()
    {
        shotControl.ShotTurret();
        if (shotControl.Target != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(shotControl.Target);
            turretTank.transform.rotation = Quaternion.Slerp(turretTank.transform.rotation, targetRotation, rotateTurretSpeed * Time.deltaTime);
            turretTank.transform.rotation = turretTank.transform.rotation;
        }
        else
        {
            turretTank.transform.rotation = turretTank.transform.rotation;
        }
    }
}
