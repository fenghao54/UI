using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Com_Item:MonoBehaviour
{
    public Transform Item;
    void Start()
    {
        Item = gameObject.transform.Find("Tran_Drag");
        var a=Item.gameObject.AddComponent<Drag2>();
    }
}
