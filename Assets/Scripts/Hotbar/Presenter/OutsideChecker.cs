using Hotbar.Container;
using Hotbar.Manager;
using Hotbar.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideChecker : MonoBehaviour
{

    //�з��� ���� �ϴ� ���
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            var npc = other.gameObject.GetComponent<NPCPresenter>();
            if (npc.isInside == true)
            {
                "�����ؼ� �����!".Log();
                NPCContainer.Instance.npcCreateCount--;
                Destroy(other.gameObject);

            }
        }
    }
    */

    //ž������ ���� ��� && �з��� �����ϴ� ���
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "NPC")
        {
            if(SubwayManager.Instance.isClose || other.gameObject.GetComponent<NPCPresenter>().isInside)
            {
                "ž�� �����ؼ� �����!".Log();
                Destroy(other.gameObject);
            }
        }
    }
}
