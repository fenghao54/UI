using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerClickHandler,IPointerDownHandler
{

    public Collider2D targetPosition;
    public Item_Manager item_manager;
    void Start ()
    {
        item_manager = FindObjectOfType<Item_Manager>();
        targetPosition = FindObjectOfType<Collider2D>();
    }
	
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var clos = Physics2D.OverlapCircleAll(gameObject.transform.position, 1);
        //if (Equals(clos,targetPosition))
        //{
        //    gameObject.SetActive(false);
        //}
        foreach (var clo in clos)
        {
            if (clo == targetPosition)
            {
                Destroy(gameObject);
                BagData.Instance.itemList.RemoveAt(item_manager.currentItemNum-1);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
