using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag2:UIBase
{
    private Vector3 initalPos;
    public Item_Manager item_manager;
    public Transform Item_parent;//用来可以全局拖拽
    public Transform content;
    
    //public Transform content;//鼠标抬起之后返回到原来的位置
    void Start()
    {
        initalPos = gameObject.transform.position;
        item_manager = FindObjectOfType<Item_Manager>();
        Item_parent = GameObject.Find("Area").transform;
        content=item_manager.transform.Find("Canvas/Scroll View/Viewport/Content");
        SeTriggerListener(gameObject).onDrag+=OnDrag;
        SeTriggerListener(gameObject).onPointUp += OnPointerUp;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
        
        gameObject.transform.SetParent(Item_parent);//当拖动的时候，设置父节点为“Area”
      
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
            gameObject.transform.SetParent(content);
            gameObject.transform.localPosition = Vector3.one;
        }
       
       
    }
}
