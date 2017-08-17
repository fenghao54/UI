using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour {

    public EvenTriggerListener SeTriggerListener(GameObject rObj)
    {
        var eventLister = rObj.GetComponent<EvenTriggerListener>();
        if (eventLister == null)
        {
            eventLister = rObj.AddComponent<EvenTriggerListener>();
        }
        return eventLister;
    }

}
