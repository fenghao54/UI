using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;
using DG.Tweening;

public class HanderControl : MonoBehaviour
{
    private LeapProvider provider;
    private Frame frame;//

    private GameObject bottle;
    private GameObject bottle2;

    public float distance = 0.001f;//设置物品和掌心的距离

    private Vector3 InitalPos;//物体的初始位置
    private Vector3 InitalPos2;
    private Vector3 targetPos;//物体移动的目标位置

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        bottle = GameObject.Find("Point_a");
        bottle2 = GameObject.Find("Point_b");
        InitalPos = bottle.transform.position;
        InitalPos2 = bottle2.transform.position;
    }

    void Update()
    {
        frame = provider.CurrentFrame;//获取当前的骨架位置
        CheckHands();
    }
    /// <summary>
    /// 移动物品随手移动
    /// </summary>
    void MoveItem(Hand hand, GameObject bottle)
    {
        GameObject a=new GameObject();
        Vector3 b = Vector3.Cross(hand.Direction.ToVector3(), hand.PalmNormal.ToVector3());
        a.transform.position= hand.PalmPosition.ToVector3()
            + hand.PalmNormal.ToVector3().normalized * distance*2;
        bottle.transform.position = hand.PalmPosition.ToVector3()
            + hand.PalmNormal.ToVector3().normalized * distance;
         bottle.transform.LookAt(a.transform,b);
        Destroy(a);
        
    }
    void MoveItem2(Hand hand, GameObject bottle)
    {
        GameObject a = new GameObject();
        Vector3 b = Vector3.Cross(hand.Direction.ToVector3(), hand.PalmNormal.ToVector3());
        a.transform.position = hand.PalmPosition.ToVector3()
            + hand.PalmNormal.ToVector3().normalized * distance * 2;
        bottle.transform.position = hand.PalmPosition.ToVector3()
            + hand.PalmNormal.ToVector3().normalized * distance;
        bottle.transform.LookAt(a.transform, -b);
        Destroy(a);

    }

    //void LookAt(Hand hand)
    //{
    //    var offset = (hand.PalmNormal.ToVector3() - bottle.transform.right).normalized;
    //    Debug.Log(offset);
    //    Quaternion dir = Quaternion.LookRotation(offset);
    //    bottle.transform.rotation = dir;
    //}

    /// <summary>
    /// 判断进入的手的指尖距离，以及掌心到物品的距离
    /// </summary>
    void CheckHands()
    {

        if (frame.Hands.Count > 0)
        {
            foreach (Hand pair in frame.Hands)//检测进入的手的数量;
            {
                float offset = (pair.Fingers[0].TipPosition.ToVector3() - pair.Fingers[2].TipPosition.ToVector3()).magnitude;
                float offset_Item = (pair.PalmPosition.ToVector3() - bottle.transform.position).magnitude;//分别算两个物体到掌心的距离
                float offset_Item2 = (pair.PalmPosition.ToVector3() - bottle2.transform.position).magnitude;
                //Debug.Log("1"+offset);
                //Debug.Log("2"+offset_Item);
                if (offset < 0.07 && offset_Item < 0.07)
                {
                   
                    MoveItem(pair, bottle);//检测的那只手抓起第一个物品
                }

                else
                {
                   
                    bottle.transform.DOMove(InitalPos,1);
                    bottle.transform.up = new Vector3(0, 1, 0);
                }

                if (offset < 0.1 && offset_Item2 < 0.06)
                {
                    MoveItem2(pair, bottle2);//检测的那只手抓起第二个物品
                }

                else
                {
                    bottle2.transform.DOMove(InitalPos2, 1);
                    bottle2.transform.up=new Vector3(0,1,0);
                }
            }
        }

    }
}
