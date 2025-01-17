using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Image image;
    public string answer;
    [HideInInspector] public bool movable = true;
    [HideInInspector] public Transform parentAfterDrag;
    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (movable == true)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (movable == true)
        {
            Vector3 worldPosition;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                transform.parent.GetComponent<RectTransform>(),
                Input.mousePosition,
                eventData.pressEventCamera,
                out worldPosition
            );
            transform.position = worldPosition;
        }
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
