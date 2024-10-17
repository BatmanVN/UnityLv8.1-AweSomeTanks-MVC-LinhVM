using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private AsyncOperation loadingOperation;
    private float countTime;
    private void Start()
    {

    }
    public void StartLoading(string nameScene)
    {
        gameObject.SetActive(true);
        DontDestroyOnLoad(this);
        loadingOperation = SceneManager.LoadSceneAsync(nameScene);
        countTime = Time.unscaledTime;
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if (loadingOperation == null) return;
        float totalTime = (Time.unscaledTime - countTime);
        float finsihTime = Mathf.Min(totalTime, loadingOperation.progress);
        if (loadingOperation.isDone && finsihTime >= 1f)
        {
            DestroyLoading();
            Debug.Log(finsihTime);
        }
    }
    private void DestroyLoading()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
