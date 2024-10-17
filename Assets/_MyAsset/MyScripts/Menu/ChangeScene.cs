using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void PlayOrBack(string nameScene)
    {
       SceneManager.LoadSceneAsync(nameScene);
    }
}
