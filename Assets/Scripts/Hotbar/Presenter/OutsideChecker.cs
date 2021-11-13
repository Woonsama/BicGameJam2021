using Hotbar.Container;
using Hotbar.Manager;
using Hotbar.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideChecker : MonoBehaviour
{

    //ž�� �ϴ� ���
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            "����!".Log();
            other.gameObject.GetComponent<NPCPresenter>().isInside = true;
        }
    }

    //���� �ϴ� ���
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            var npc = other.gameObject.GetComponent<NPCPresenter>();
            if (npc.isInside == true)
            {
                "�����ؼ� �����!".Log();
                NPCContainer.Instance.RemoveNPC(npc.ID);
            }
        }
    }
    
    //ž������ ���� ���
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "NPC")
        {
            if(SubwayManager.Instance.isClose)
            {
                "ž�� �����ؼ� �����!".Log();
                NPCContainer.Instance.RemoveNPC(other.gameObject.GetComponent<NPCPresenter>().ID);
            }
        }
    }
}
