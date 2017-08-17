using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Manager :UIBase {



    public GameObject Com_Item2;

    public RectTransform rectTran;//是content 对象，也是控制滑动平面大小的

    public Button Btn_AddItem;

    public Button Btn_RemoveItem;

    public Button Btn_Close;

    public GridLayoutGroup grid;//控制行距，和物品间距

    public int currentItemNum;

    //private Toggle startItem;

    void Start()
    {
        Btn_AddItem = gameObject.transform.Find("Canvas/Button").GetComponent<Button>();
        Btn_RemoveItem = gameObject.transform.Find("Canvas/Btn_Remove").GetComponent<Button>();
        Btn_Close= gameObject.transform.Find("Canvas/Btn_Close").GetComponent<Button>();
        rectTran = gameObject.transform.Find("Canvas/Scroll View/Viewport/Content").GetComponent<RectTransform>();
        grid = rectTran.transform.GetComponent<GridLayoutGroup>();

        
        SeTriggerListener(Btn_AddItem.gameObject).onClick += AddItem;
        SeTriggerListener(Btn_RemoveItem.gameObject).onClick += RemoveItem;
        SeTriggerListener(Btn_Close.gameObject).onClick += CloseMenu;

        //Btn_AddItem.onClick.AddListener(AddItem);//添加监听事件，当点击的时候运行AddItem的函数。
        //Btn_RemoveItem.onClick.AddListener(RemoveItem);
        //Btn_Close.onClick.AddListener(CloseMenu);
        Com_Item2 = Resources.Load("Com_Item") as GameObject;
        Init();
    }

  

    public void Init()
    {
        for (int i = 0; i < BagData.Instance.itemList.Count; i++)
        {

            UIManager.Instance.AddComUI<Com_Item>(rectTran);
            currentItemNum++;
        }
    }

    public void AddItem()
    {

        UIManager.Instance.AddComUI<Com_Item>(rectTran);
        currentItemNum++;

        var item = new ItemData();
        item.name = "";
        BagData.Instance.itemList.Add(new ItemData());
 
        ChangeHight();
    }

    public void RemoveItem()
    {
        Destroy(rectTran.transform.GetChild(currentItemNum - 1).gameObject);
        BagData.Instance.itemList.RemoveAt(currentItemNum - 1);
        currentItemNum--;
       
        ChangeHight();
    }

    public void CloseMenu()
    {
        GameObject a = gameObject;
        //startItem.isOn = false;
        Destroy(a);
    }

    /// <summary>
    /// 物件的大小加上行距
    /// </summary>
    public void ChangeHight()
    {
        float itemHight = grid.spacing.y + grid.cellSize.y;

        rectTran.sizeDelta = new Vector2(0, itemHight * Mathf.Ceil((float)currentItemNum / grid.constraintCount));//设置高度是几倍行距+自身距离
    }


}

