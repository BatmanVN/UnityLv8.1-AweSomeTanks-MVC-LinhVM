using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EnemyTurret : Gun
{
    private float interval;
    private float lastShot;
    [SerializeField] private bool isShoting;
    [SerializeField] private GameObject effectShot;
    private Vector3 target;
    public Vector3 Target { get => target; }
    private void Start()
    {
        interval = 60f / rpm;
        bulletPool = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<LeanGameObjectPool>();
    }
    private void Update()
    {
        
    }
    public void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            lastShot = Time.time;
            Shot();
            effectShot.SetActive(true);
            Invoke(nameof(DeActive), 0.15f);
        }
    }
    public void DeActive()
    {
        effectShot.SetActive(false);
    }
    protected void Shot()
    {
        AddProjecttile();
        anim.SetTrigger("Shot");
    }
    //Despawn truyen vao prefab dc sinh ra , va se bien mat sau 1s
    //Spawn set gan vi tri bullet dc sinh ra va rotation cua vi tri do
    protected void AddProjecttile()
    {
        GameObject bullet = bulletPool.Spawn(pointBulletAppear.position, pointBulletAppear.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * speedBullet;
        bulletPool.Despawn(bullet, timeDisable);
    }
}
