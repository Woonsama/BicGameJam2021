using Cysharp.Threading.Tasks;
using Hotbar.Container;
using Hotbar.Pattern;
using Hotbar.UI;
using Hotbar.UI.View;
using System.Threading.Tasks;

namespace Hotbar.Manager
{
    public class MainSceneManager : SingletonMonoBase<MainSceneManager>
    {
        public bool isGameClear = false;

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
            SubwayManager.Instance.Play();

            //Check Game Clear
            _ = CheckClear();
        }

        #region Private

        private async Task CheckClear()
        {
            await UniTask.WaitUntil(() => isGameClear == true);
            //Open Game Clear Popup
        }

        #endregion
    }
}

