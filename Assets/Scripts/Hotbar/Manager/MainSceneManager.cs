using Hotbar.Pattern;
using Hotbar.UI;
using Hotbar.UI.View;
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
            //노선도
            var routeMapView = await UIManager.Instance.OpenView(UIManager.ViewType.RouteMap);
            await (routeMapView as UIRouteMapView).StartAnimation();

            //게임 시작
        }
    }
}

