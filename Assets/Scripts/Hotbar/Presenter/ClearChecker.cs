using Hotbar.Container;
using Hotbar.Manager;
using Hotbar.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Presenter
{
    public class ClearChecker : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                SubwayManager.Instance.isFinished = true;

                if(SubwayManager.Instance.DepartCheck() == true)
                {
                    "[���� Ŭ����]".LogError();
                    UIManager.Instance.OpenView(UIManager.ViewType.Clear);
                }
                else
                { 
                    "[���� Ŭ���� ����]".LogError();
                    UIManager.Instance.OpenView(UIManager.ViewType.Fail);

                }
            }
        }
    }
}


