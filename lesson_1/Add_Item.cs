using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add_Item : MonoBehaviour
{

    public GameObject Item_new;
    public Button Btn_AddItem;
    

    void Start ()
	{
	    Btn_AddItem = gameObject.transform.Find("Button").GetComponent<Button>();
        Btn_AddItem.onClick.AddListener(AddMenu);
	}

    void AddMenu()
    {
        Item_new = UIManager.Instance.AddpageUI("Paker_new");//添加UI对象
        Item_new.AddComponent<Item_Manager>();//给物品栏增加物品管理脚本
    }

}
