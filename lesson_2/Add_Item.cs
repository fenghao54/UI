using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add_Item : MonoBehaviour
{

    //public GameObject Item_new;
    public Button Btn_AddItem;
    

    void Start ()
	{
	    Btn_AddItem = gameObject.transform.Find("Button").GetComponent<Button>();
        Btn_AddItem.onClick.AddListener(AddMenu);
	}

    void AddMenu()
    {
        var Item_new = UIManager.Instance.AddpageUI<Item_Manager>(); //添加UI对象
    }

}
