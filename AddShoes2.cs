using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddShoes2 : MonoBehaviour {



    public GameObject Com_Item;

    public RectTransform rectTran;//是content 对象，也是控制滑动平面大小的

    public Button Btn_AddItem;

    public GridLayoutGroup grid;//控制行距，和物品间距

    public int currentItemNum;

    void Start()
    {
        Btn_AddItem = gameObject.transform.Find("Canvas/Button").GetComponent<Button>();
        rectTran = gameObject.transform.Find("Canvas/Scroll View/Viewport/Content").GetComponent<RectTransform>();
        grid = rectTran.transform.GetComponent<GridLayoutGroup>();

        Btn_AddItem.onClick.AddListener(AddItem);//添加监听事件，当点击的时候运行AddItem的函数。
        Com_Item = Resources.Load("Item_shoot") as GameObject;
        
    }

    public void AddItem()
    {
        var obj = GameObject.Instantiate(Com_Item) as GameObject;
        obj.transform.SetParent(rectTran);
 
        obj.gameObject.transform.localScale = Vector3.one;//使新实例化的物体大小和父级的大小比例一致
        currentItemNum++;

        ChangeHight();
    }


    public void ChangeHight()
    {
        float itemHight = grid.spacing.y + grid.cellSize.y;//物件的大小加上行距

        rectTran.sizeDelta = new Vector2(0, itemHight * Mathf.Ceil((float)currentItemNum / grid.constraintCount));//设置高度是几倍行距+自身距离
    }


}

