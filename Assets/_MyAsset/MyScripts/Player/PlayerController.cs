using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseTank
{
    [SerializeField] protected PlayerTakeDame takeDame;
    [SerializeField] private TankMove moveControl;
    [SerializeField] private TurreDefault shotControl;
    [SerializeField] private GameObject smokeEffect;
    private void Start()
    {

    }
    private void Update()
    {
        PlayerMove();
        PlayerShot();
        TakeDame();
    }
    protected void PlayerMove()
    {
        if (!health.isDead)
        {
            moveControl.MoveControl();
            if (moveControl.MoveDirection != Vector3.zero)
            {
                Rotate(moveControl.MoveDirection, baseTank);
                smokeEffect.SetActive(true);
            }
            else
            {
                baseTank.transform.rotation = baseTank.transform.rotation;
                smokeEffect.SetActive(false);
            }
        }
    }
    protected void PlayerShot()
    {
        if (!health.isDead)
        {
            shotControl.ShotTurret();
            if (shotControl.Target != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(shotControl.Target);
                turretTank.transform.rotation = Quaternion.Slerp(turretTank.transform.rotation, targetRotation, rotateTurretSpeed * UnityEngine.Time.deltaTime);
            }
            else
            {
                turretTank.transform.rotation = turretTank.transform.rotation;
            }
        }
    }
    protected void TakeDame()
    {
        if (takeDame.isAttacked )
        {
            if (GameObject.FindGameObjectWithTag(StringConst.enemyCanon).GetComponent<EnemyTurret>() == null) return;
            gun = GameObject.FindGameObjectWithTag(StringConst.enemyCanon).GetComponent<EnemyTurret>();
            health.TakeDame(gun.GetComponent<EnemyTurret>().Dame);
            takeDame.isAttacked = false;
        }
    }
    public void Destroy()
    {
        HitSurface hitSurface = this.gameObject.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(baseTank.transform.position);
                exploPrefab = Instantiate(effectPrefab, baseTank.transform.position, effectRotation);
            }
        }
        Destroy(turretTank);
        Destroy(exploPrefab, Time);
    }
}
