using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
    [SerializeField] private BaseMission baseMission;
    [SerializeField] protected GameObject missionComplete;
    [SerializeField] protected GameObject effect;
    [SerializeField] protected AudioSource win;
    public void WinLevel()
    {
        if (baseMission.Count >= 2 && TankCount.Instance.Count >= 8)
        {
            missionComplete.SetActive(true);
            effect.SetActive(true);
        }
    }
    private void Update()
    {
        WinLevel();
    }
}
