using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Gun
{
    private float interval;
    private float lastShot;
    [SerializeField] private bool isShoting;
    private Vector3 target;
    public Vector3 Target { get => target; }
    private void Start()
    {
        interval = 60f / rpm;
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
        }
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
