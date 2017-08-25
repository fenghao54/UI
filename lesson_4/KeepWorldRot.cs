using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWorldRot : MonoBehaviour {

    public Vector3 eulerAngles;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = eulerAngles;
    }
}
