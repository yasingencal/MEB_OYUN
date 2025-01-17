using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public void CorrectAnswer()
    {
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (clickedButton != null)
        {
            EventManager.instance.TriggerCorrectAnswer();
            clickedButton.interactable = false;

            Transform tickTransform = clickedButton.transform.Find("Tick");
            tickTransform.gameObject.SetActive(true);
        }
    }
    public void WrongAnswer()
    {
        EventManager.instance.TriggerWrongAnswer();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        Debug.Log("Game exited (only in Editor)");
        #else
            Application.Quit();
        #endif
    }
}
