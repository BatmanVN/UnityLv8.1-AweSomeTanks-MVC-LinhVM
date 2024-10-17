using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMission : MissionCategories
{
    public void CheckBase()
    {
        count++;
        text.text = Count.ToString();
    }
}
