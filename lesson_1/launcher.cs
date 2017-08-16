using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcher : MonoBehaviour {

    void Awake()
    {
        GameObject UIMag = new GameObject("UIMag");
        DontDestroyOnLoad(UIMag);
        UIMag.AddComponent<UIManager>();

        GameObject paker = UIManager.Instance.AddpageUI("Btn_Menu");//加一个菜单按钮，用UIManager的单例创建
        paker.AddComponent<Add_Item>();

        

    }


}
