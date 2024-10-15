using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null)
            {
                T newInstance = FindAnyObjectByType<T>();
                RegsisterInstance(newInstance);
            }
            return instance;
        }
    }
    private void Awake()
    {
       if (instance == null)
        {
            RegsisterInstance((T)(MonoBehaviour)this);
        }
       else if(instance != null)
        {
            Destroy(this);
        }
    }

    private static void RegsisterInstance(T newInstance)
    {
        if (newInstance == null) return;
        instance = newInstance;
    }
}
