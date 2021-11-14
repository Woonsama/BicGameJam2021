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
                    "[게임 클리어]".LogError();
                    UIManager.Instance.OpenView(UIManager.ViewType.Clear);
                }
                else
                { 
                    "[게임 클리어 실패]".LogError();
                    UIManager.Instance.OpenView(UIManager.ViewType.Fail);

                }
            }
        }
    }
}


