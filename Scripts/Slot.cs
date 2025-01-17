using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IDropHandler
{
    public string rightAnswer;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableObject obj = dropped.GetComponent<DraggableObject>();
        if (obj.answer == rightAnswer)
        {
            EventManager.instance.TriggerCorrectAnswer();
            obj.parentAfterDrag = transform;
            obj.movable = false;
        }
        else
        {
            EventManager.instance.TriggerWrongAnswer();
        }
    }
}
