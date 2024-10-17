using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] protected GameObject baseTank;
    [SerializeField] protected GameObject turretTank;
    [SerializeField] protected Health health;
    [SerializeField] private GameObject healthBar;
    [SerializeField] protected Transform explosivePoint;
    [SerializeField] protected GameObject exploPrefab;
    [SerializeField] protected Animator anim;
    [SerializeField] private float time;
    [SerializeField] protected float rotateBaseSpeed;
    [SerializeField] protected float rotateTurretSpeed;
    protected float rotateVelocity;

    public GameObject HealthBar { get => healthBar; set => healthBar = value; }
    public float Time { get => time; set => time = value; }
    public Gun Gun { get => gun; set => gun = value; }

    public void Rotate(Vector3 target, GameObject baseTank)
    {
        Quaternion targetRotate = Quaternion.LookRotation(target);
        float yRotation = Mathf.SmoothDampAngle(baseTank.transform.eulerAngles.y,
            targetRotate.eulerAngles.y, ref rotateVelocity, rotateBaseSpeed * (UnityEngine.Time.deltaTime * 5));
        baseTank.transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
}
