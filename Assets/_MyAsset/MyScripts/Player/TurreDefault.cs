using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurreDefault : Gun
{
    [SerializeField] private VariableJoystick shotJoystick;
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
        UpdateFiring();
    }
    public void ShotTurret()
    {
        float hInput = shotJoystick.Horizontal;
        float vInput = shotJoystick.Vertical;
        target = new Vector3(hInput, 0f, vInput);
        target = Camera.main.transform.TransformDirection(target);
        target.y = 0f;
    }
    protected void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            lastShot = Time.time;
            Shot();
        }
    }
    protected void Shot()
    {
        if (isShoting)
        {
            AddProjecttile();
            anim.SetTrigger("Shot");
        }
    }
    //Despawn truyen vao prefab dc sinh ra , va se bien mat sau 1s
    //Spawn set gan vi tri bullet dc sinh ra va rotation cua vi tri do
    protected void AddProjecttile()
    {
        GameObject bullet = bulletPool.Spawn(pointBulletAppear.position, pointBulletAppear.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * speedBullet;
        bulletPool.Despawn(bullet, timeDisable);
    }
    public void StartShot()
    {
        isShoting = true;
    }

    public void StopShot()
    {
        isShoting = false;
    }

}
