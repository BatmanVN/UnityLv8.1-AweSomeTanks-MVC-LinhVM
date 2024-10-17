using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoint;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemiesCount;
    [SerializeField] protected float spawnInterval;
    [SerializeField] protected Health baseEnemy;
    protected bool isDetected;
    private Coroutine spawn;
    private void Start()
    {
        foreach (Transform child in transform)
        {
            spawnPoint.Add(child);
        }
        baseEnemy = GetComponentInParent<Health>();
    }
    public void SpawnEnemy()
    {
        int randomSpawn = Random.Range(0,spawnPoint.Count);
        if (spawnPoint[randomSpawn] != null)
        {
            GameObject tank = Instantiate(enemyPrefab, spawnPoint[randomSpawn].position, spawnPoint[randomSpawn].rotation);
            enemiesCount--;
            spawnPoint.RemoveAt(randomSpawn);
            TankManager.Instance.AddTank(tank);

        }
    }
    private void OnTriggerEnter(Collider detective)
    {
        if (detective.CompareTag(StringConst.playerParaname) && !isDetected)
        {
            isDetected = true;
            spawn = StartCoroutine(SpawnEnemiesByTime());
        }
    }
    private void OnTriggerExit(Collider detective)
    {
        if (detective.CompareTag(StringConst.playerParaname) && !isDetected)
        {
            isDetected = false;
            StopCoroutine(spawn);
        }
    }

    private IEnumerator SpawnEnemiesByTime()
    {
        while (enemiesCount > 0 && !baseEnemy.isDead)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }
}
