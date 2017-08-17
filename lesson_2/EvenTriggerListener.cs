using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EvenTriggerListener : MonoBehaviour,IPointerUpHandler,IPointerClickHandler,IDragHandler,IBeginDragHandler
{
    public UnityAction onClick;
    public UnityAction<PointerEventData> onDrag;
    public UnityAction<PointerEventData> onBeginDrag;
    public UnityAction<PointerEventData> onPointUp;
    public void OnPointerUp(PointerEventData eventData)
    {
        if (onPointUp != null)
        {
            onPointUp(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null)
        {
            onClick();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null)
        {
            onDrag(eventData);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDrag != null)
        {
            onBeginDrag(eventData);
        }
    }
}
