using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Dead()
    {
        base.Dead();
        TankCount.Instance.CheckTank();
    }
}
