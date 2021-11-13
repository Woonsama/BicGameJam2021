using Hotbar.Manager;
using Hotbar.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Presenter
{
    public class ClearChecker : MonoBehaviour
    {
        public async void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                if(SubwayManager.Instance.DepartCheck() == true)
                {
                    "[���� Ŭ����]".LogError();
                    await UIManager.Instance.OpenView(UIManager.ViewType.Clear);
                }
                else
                {
                    "[���� Ŭ���� ����]".LogError();
                    await UIManager.Instance.OpenView(UIManager.ViewType.Fail);
                }
            }
        }
    }
}


