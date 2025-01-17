using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Slider levelBar;

    [SerializeField] GameObject startPanel,transitionPanel;
    [SerializeField] private Level[] level;
    public static LevelManager instance;
    int correct = 0,levelCount=0;
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
    private void Start()
    {
        levelBar.maxValue = level.Length - 1;
    }
    private void OnEnable()
    {
        EventManager.OnCorrectAnswer += EventManager_OnCorrectAnswer;
        EventManager.OnWrongAnswer += EventManager_OnWrongAnswer;
    }

    private void EventManager_OnWrongAnswer()
    {
        
    }

    private void EventManager_OnCorrectAnswer()
    {
        correct++;

        if (correct == level[levelCount].question)
        {
            correct = 0;
            transitionPanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        EventManager.OnCorrectAnswer -= EventManager_OnCorrectAnswer;
        EventManager.OnWrongAnswer -= EventManager_OnWrongAnswer;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        level[levelCount].scene.SetActive(true);
        levelBar.gameObject.SetActive(true);
        levelBar.value = levelCount+1;
    }
    public void ChangeLevel()
    {
        transitionPanel.SetActive(false);
        level[levelCount].scene.SetActive(false);
        levelCount++;
        level[levelCount].scene.SetActive(true);
        levelBar.value = levelCount + 1;

        if (levelCount == level.Length-1)
        {
            levelBar.gameObject.SetActive(false);
        }
    }

}
