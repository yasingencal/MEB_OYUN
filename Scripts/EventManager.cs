using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public static Action OnCorrectAnswer;
    public static Action OnWrongAnswer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerCorrectAnswer()
    {
        OnCorrectAnswer?.Invoke();
    }
    public void TriggerWrongAnswer()
    {
        OnWrongAnswer?.Invoke();
    }

}
