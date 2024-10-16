using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate<T>
{
    public void OnEnter(T t);
    public void OnExercute(T t);
    public void OnExit(T t);
}
