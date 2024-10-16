using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : BaseTank
{
    [SerializeField] private EnemyTurret turret;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private HealthBar bar;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject smokerEffect;
    [SerializeField] private TankCount tank;
    [SerializeField] protected Istate<EnemyController> currentState;
    [SerializeField] private float radius;
    public float radiusRandom;
    public bool isTakedDame;
    public bool isDetected;
    protected Vector3 directionRandom;
    public NavMeshAgent Nav { get => nav;}
    public GameObject Enemy { get => enemy; set => enemy = value; }
    public bool IsTakedDame { get => isTakedDame; set => isTakedDame = value; }
    public float Radius { get => radius; set => radius = value; }

    private void Start()
    {
        ChangeState(new IdleState());
    }

    private void Update()
    {
        StateControl();
        CheckEnemy();
    }
    public void ChangeState(Istate<EnemyController> newState)
    {
        if (currentState != null)
            currentState.OnExit(this);
        currentState = newState;
        if (currentState != null)
            currentState.OnEnter(this);
    }

    protected void StateControl()
    {
        if (currentState != null)
            currentState.OnExercute(this);
    }

    public void MoveToPoint(Vector3 target)
    {
        if (!health.isDead)
        {
            nav.SetDestination(target);
            nav.stoppingDistance = 5f;
        }
        else
        {
            isTakedDame = false;
        }
    }
    public void CheckEnemy()
    {
        Collider[] detective = Physics.OverlapSphere(baseTank.transform.position, radius);
        foreach (Collider detec in detective)
        {
            if (detec.gameObject.CompareTag(StringConst.playerParaname))
            {
                if (!health.isDead)
                {
                    enemy = detec.gameObject;
                    isDetected = true;
                    if (enemy != null)
                    {
                        RotateTurret(enemy.transform.position);
                    }
                    if (enemy.GetComponent<Health>().isDead)
                    {
                        enemy = null;
                    }
                }
            }
        }
    }
    public void RotateTurret(Vector3 target)
    {
            Quaternion targetRotation = Quaternion.LookRotation(target - turretTank.transform.position);
            turretTank.transform.rotation = Quaternion.Slerp(turretTank.transform.rotation, targetRotation, rotateTurretSpeed * UnityEngine.Time.deltaTime);
    }

    public void Attack()
    {
        if (Enemy != null && !enemy.GetComponent<Health>().isDead)
        {
            turret.UpdateFiring();
        }
    }
    private void OnTriggerEnter(Collider tank)
    {
        if (tank.CompareTag(StringConst.bulletPlayer))
        {
            enemy = GameObject.FindGameObjectWithTag(StringConst.playerParaname);
            isTakedDame = true;
        }
    }
    public void MoveRandom()
    {
        Vector3 randomPoint = SetRandomPostion(3f);
        MoveToPoint(randomPoint);
        nav.stoppingDistance = 0f;
        Quaternion direction = Quaternion.LookRotation(randomPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, rotateBaseSpeed * UnityEngine.Time.deltaTime);
    }
    public Vector3 SetRandomPostion(float radius)
    {
        directionRandom = Random.insideUnitSphere * radius;
        directionRandom += transform.position;
        if (NavMesh.SamplePosition(directionRandom, out NavMeshHit hit, radius, 1))
        {
            return hit.position;
        }
        return transform.position;
    }
    public void EnableHealthBar()
    {
        HealthBar.SetActive(true);
        bar.UpdateHealthBar(health.HealthPoint, health.MaxHealth);
    }
    public void Destroy()
    {
        this.enabled = false;
        HitSurface hitSurface = this.gameObject.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(transform.position);
                exploPrefab = Instantiate(effectPrefab, transform.position, effectRotation);
            }
        }
        Destroy(this.gameObject,0.5f);
        Destroy(exploPrefab, Time);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(baseTank.transform.position, radius);
    }
}
