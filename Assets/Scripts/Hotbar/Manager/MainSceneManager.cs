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
            //노선도
            var routeMapView = await UIManager.Instance.OpenView(UIManager.ViewType.RouteMap);
            await (routeMapView as UIRouteMapView).StartAnimation();

            //NPC 세팅
            NPCContainer.Instance.CreateNPC(30);

            //Player 세팅
            Player.Instance.CreatePlayer();

            //Subway 프레임워크 시작
        }
    }
}

