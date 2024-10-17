using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPause : MonoBehaviour
{
    public void Pause(float time)
    {
        Time.timeScale = time;
    }
    public void DisablePause(float time)
    {
        Time.timeScale = time;
    }
}
