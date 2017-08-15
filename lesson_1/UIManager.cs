using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject UIRoot;

    void Awake ()
    {
        Instance = this;
        inital();
    }

    private void inital()
    {
        UIRoot = (GameObject)Resources.Load("UIRoot");
        if (UIRoot != null)
        {
            UIRoot = GameObject.Instantiate(UIRoot);
            UIRoot.name = "UIRoot";

            DontDestroyOnLoad(UIRoot);
            
        }
    }


    public GameObject AddpageUI(string  rname)//在resource文件夹中加载UI对象，并实例一个加到UI.transform的父节点下面
    {
        GameObject a = (GameObject)Resources.Load(rname);
        if (a == null)
        {
            Debug.Log("没有找到资源");
            return null ;
        }
        a=Instantiate(a) as GameObject;
        a.name = rname;
        a.transform.SetParent(UIRoot.transform);
        a.transform.localScale=Vector3.one;
        return a;
    }
}
