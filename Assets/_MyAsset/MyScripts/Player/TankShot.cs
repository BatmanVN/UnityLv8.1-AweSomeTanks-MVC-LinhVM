using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShot : MonoBehaviour
{
    [SerializeField] private VariableJoystick shotJoystick;
    private bool isShot;
    private Vector3 target;

    public Vector3 Target { get => target;}

    public void ShotTurret()
    {
        float hInput = shotJoystick.Horizontal;
        float vInput = shotJoystick.Vertical;
        target = new Vector3(hInput, 0f , vInput);
        target = Camera.main.transform.TransformDirection(target);
        target.y = 0f;
    }
    public void ShotTuret()
    {
        isShot = true;
    }
    public void CancelShot()
    {
        isShot = false;
    }
}
