using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : MonoBehaviour
{
    [SerializeField] protected float rotateBaseSpeed;
    [SerializeField] protected float rotateTurretSpeed;
    protected float rotateVelocity;

    public void Rotate(Vector3 target, GameObject baseTank)
    {
        Quaternion targetRotate = Quaternion.LookRotation(target);
        float yRotation = Mathf.SmoothDampAngle(baseTank.transform.eulerAngles.y,
            targetRotate.eulerAngles.y, ref rotateVelocity, rotateBaseSpeed * (Time.deltaTime * 5));
        baseTank.transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
}
