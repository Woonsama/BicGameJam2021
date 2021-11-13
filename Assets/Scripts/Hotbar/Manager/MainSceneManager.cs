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
        public async void Awake()
        {
            //Show Tutorial
            var tutorialView = await UIManager.Instance.OpenView(UIManager.ViewType.Tutorial);
            await (tutorialView as UITutorialView).StartTutorial();

            //Set Station Data
            SubwayManager.Instance.InitStation();

            //Show Route Map
            var routeMapView = await UIManager.Instance.OpenView(UIManager.ViewType.RouteMap);
            //await (routeMapView as UIRouteMapView).StartAnimation();

            //NPC Init
            NPCContainer.Instance.Init();

            //Player Init
            PlayerContainer.Instance.Init();

            //Camera Init
            CameraManager.Instance.Init();

            //Subway Init
            SubwayManager.Instance.Play();
        }
    }
}

