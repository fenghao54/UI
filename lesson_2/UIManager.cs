using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : UIBase
{
    public static UIManager Instance;
    public GameObject UIRoot;
    public Transform Paker_new;

    public  Dictionary<string,MonoBehaviour> uiDict = new Dictionary<string, MonoBehaviour>();

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


    public T AddpageUI<T>() where T:MonoBehaviour//在resource文件夹中加载UI对象，并实例一个加到UI.transform的父节点下面
    {
        string rName = typeof(T).Name;
        GameObject a = (GameObject)Resources.Load(rName);
        if (a == null)
        {
            Debug.Log("没有找到资源");
            return null ;
        }
        a=Instantiate(a) as GameObject;
        a.name = rName;
        a.transform.SetParent(UIRoot.transform);
        a.transform.localScale=Vector3.one;
        var script= a.AddComponent<T>();
        uiDict.Add(rName,script);

        return script;
    }

    public T AddComUI<T>(Transform parent) where T:MonoBehaviour
    {
        string rName = typeof(T).Name;
        GameObject a = (GameObject)Resources.Load(rName);
        if (a == null)
        {
            Debug.Log("没有找到资源");
            return null;
        }
        a = Instantiate(a, parent) as GameObject;
        a.name = rName;

        a.transform.localScale = Vector3.one;
        var script = a.AddComponent<T>();
     
        return script;

    }

    private void NewMethod<T>(string rName, T script) where T : MonoBehaviour
    {
        uiDict.Add(rName, script);
    }

    public T GetPageUI<T>() where T : MonoBehaviour
    {
        string rName = typeof(T).Name;
        return uiDict[rName] as T;
    }
    
}
