using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public string name;
    
}

public class BagData
{
    private static BagData _Instance;//单例，可以在外部直接调用，用来记录背包数据


    public static BagData Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new BagData();
            }

            return _Instance;
        }
    }

    public List<ItemData> itemList = new List<ItemData>();

}
