using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour {


    private GameObject bottle;
    private GameObject bottle2;
    //public GameObject huosanchufa;
    public GameObject huosan;
    private bool isbottle = false;
    private bool isbottle2 = false;

    public ParticleSystem particle;//粒子
    public ParticleSystem particle2;//粒子
    private float angle;
    private float angle2;
    void Start ()
    {
        bottle = GameObject.Find("Point_a");
        bottle2 = GameObject.Find("Point_b");
        //huosanchufa=GameObject.Find("huosanchufa");
       
    }
	
	
	void Update ()
    {
        CheckFail();
        if (angle > 90)
        {
            particle.gameObject.SetActive(true);
        }
        else
        {
            particle.gameObject.SetActive(false);
        }
        if (angle2 > 90)
        {
            particle2.gameObject.SetActive(true);
        }
        else
        {
            particle2.gameObject.SetActive(false);
        }
        drawRay();
        Debug.Log(isbottle2);
        Debug.Log(isbottle);
        if (isbottle && isbottle2)
        {
            huosan.SetActive(true);
        }
    }

    void CheckFail()
    {
        angle = Vector3.Angle(bottle.transform.up, new Vector3(0, 1, 0));//检测物品向上方向和世界坐标向下方向的夹角
        angle2= Vector3.Angle(bottle2.transform.up, new Vector3(0, 1, 0));
    }

    void drawRay()
    {
        Debug.DrawRay(bottle.transform.position,bottle.transform.up,Color.blue);
        Debug.DrawRay(bottle2.transform.position, bottle2.transform.up, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(bottle.transform.position, bottle.transform.up, out hit, 1000))
        {
            if (hit.collider.CompareTag("huosan"))
            {
                Debug.Log(1);
                isbottle = true;
            }
        }
        RaycastHit hit2;
        if (Physics.Raycast(bottle2.transform.position, bottle2.transform.up, out hit2, 1000))
        {
            if (hit2.collider.CompareTag("huosan"))
            {
                Debug.Log(2);
                isbottle2 = true;
            }
        }

    }

   
}
