using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag2 : MonoBehaviour,IDragHandler,IPointerClickHandler,IPointerUpHandler
{
    private Vector3 initalPos;
    public Item_Manager item_manager;
    void Start ()
	{
	    initalPos = gameObject.transform.position;
        item_manager = FindObjectOfType<Item_Manager>();
    }
	
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null &&
           eventData.pointerCurrentRaycast.gameObject.name == "RemoveArea")
        {
            Destroy(gameObject);
            BagData.Instance.itemList.RemoveAt(item_manager.currentItemNum - 1);
            item_manager.currentItemNum--;
        }
        else
        {
            gameObject.transform.localPosition = Vector3.one;
        }
    }
}
