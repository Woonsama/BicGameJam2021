using Hotbar.Container;
using Hotbar.Manager;
using Hotbar.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideChecker : MonoBehaviour
{

    //밀려서 하차 하는 경우
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            var npc = other.gameObject.GetComponent<NPCPresenter>();
            if (npc.isInside == true)
            {
                "하차해서 사라짐!".Log();
                NPCContainer.Instance.npcCreateCount--;
                Destroy(other.gameObject);

            }
        }
    }
    */

    //탑승하지 못한 경우 && 밀려서 하차하는 경우
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "NPC")
        {
            if(SubwayManager.Instance.isClose || other.gameObject.GetComponent<NPCPresenter>().isInside)
            {
                "탑승 실패해서 사라짐!".Log();
                Destroy(other.gameObject);
            }
        }
    }
}
