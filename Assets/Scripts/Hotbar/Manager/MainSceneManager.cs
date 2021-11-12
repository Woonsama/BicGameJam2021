using Hotbar.Container;
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
            SubwayManager.Instance.InitStation();

            //Show Route Map
            var routeMapView = await UIManager.Instance.OpenView(UIManager.ViewType.RouteMap);
            await (routeMapView as UIRouteMapView).StartAnimation();

            //NPC Init
            NPCContainer.Instance.Init();

            //Player Init
            PlayerContainer.Instance.Init();

            //Camera Init
            CameraManager.Instance.Init();

            //Subway Init
            await SubwayManager.Instance.Start();
        }
    }
}

