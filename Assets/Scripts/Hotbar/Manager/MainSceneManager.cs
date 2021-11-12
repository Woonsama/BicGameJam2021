using Hotbar.Pattern;
using Hotbar.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Hotbar.Manager
{
    public class MainSceneManager : SingletonMonoBase<MainSceneManager>
    {
        public async void Awake()
        {
            //Àü±¤ÆÇ Open
            var routeMapView = await UIManager.Instance.OpenView(UIManager.ViewType.RouteMap);
        }
    }
}

