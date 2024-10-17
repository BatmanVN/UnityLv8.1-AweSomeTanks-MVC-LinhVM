using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
    [SerializeField] private BaseMission baseMission;
    [SerializeField] protected GameObject missionComplete;
    [SerializeField] protected GameObject effect;
    public void WinLevel()
    {
        if ((baseMission.Count == 2 && TankCount.Instance.Count >= 8) 
            || (baseMission.Count == 2 && TankManager.Instance.Tanks.Count <= 0))
        {
            TankCount.Instance.condition.text = TankCount.Instance.Count.ToString();
            missionComplete.SetActive(true);
            MusicGame.Instance.music.PlayDelayed(4f);
        }
    }
    private void Update()
    {
        WinLevel();
    }
}
