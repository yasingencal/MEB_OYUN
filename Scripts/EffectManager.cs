using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private Camera uiCamera;

    [SerializeField] private GameObject greenCheckPrefab;
    [SerializeField] private GameObject redCrossPrefab;

    public static EffectManager instance;
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

    private void OnEnable()
    {
        EventManager.OnCorrectAnswer += EventManager_OnCorrectAnswer;
        EventManager.OnWrongAnswer += EventManager_OnWrongAnswer;
    }

    private void EventManager_OnWrongAnswer()
    {
        Vector3 worldPosition;
        Vector2 mousePosition = Input.mousePosition;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            canvasRectTransform,
            mousePosition,
            uiCamera,
            out worldPosition
        );
        GameObject tick = Instantiate(redCrossPrefab, canvasRectTransform);
        tick.transform.position = worldPosition;
        Destroy(tick, 0.96f);
    }

    private void EventManager_OnCorrectAnswer()
    {
        Vector3 worldPosition;
        Vector2 mousePosition = Input.mousePosition;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            canvasRectTransform,
            mousePosition,
            uiCamera,
            out worldPosition
        );
        GameObject tick = Instantiate(greenCheckPrefab, canvasRectTransform);
        tick.transform.position = worldPosition;
        Destroy(tick, 0.96f);
    }

    private void OnDisable()
    {
        EventManager.OnCorrectAnswer -= EventManager_OnCorrectAnswer;
        EventManager.OnWrongAnswer -= EventManager_OnWrongAnswer;
    }
}
