using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveMenu : MonoBehaviour
{
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private GameObject effect;
    [SerializeField] private Transform center;
    [SerializeField] private float radius;
    private void Start()
    {

    }
    public void MoveRandom()
    {
        Vector3 randomPoint = SetRandomPostion(radius);
        MoveToPoint(randomPoint);
        nav.stoppingDistance = 0.1f;
        Quaternion direction = Quaternion.LookRotation(randomPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, 15 * Time.deltaTime);
        if (nav.velocity.magnitude > 0.04f)
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);
        }
    }
    public void MoveToPoint(Vector3 target)
    {
        nav.SetDestination(target);
    }
    public Vector3 SetRandomPostion(float radius)
    {
        Vector3 directionRandom = Random.insideUnitSphere * radius;
        directionRandom += center.transform.position;
        if (NavMesh.SamplePosition(directionRandom, out NavMeshHit hit, radius, 1))
        {
            return hit.position;
        }
        return transform.position;
    }
    private void Update()
    {
        if (nav.remainingDistance <= nav.stoppingDistance || nav.velocity.magnitude <= 0.1f)
        {
            MoveRandom();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.transform.position, radius);
    }
}
