using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Hotbar.UI.View
{
    public class UIRouteMapView : UIViewBase
    {
        [Header("BackgroundImage")]
        public Image backgroundImage;

        [Header("Delay Time")]
        public float delayTime;

        public async override Task InitView()
        {
            
        }
    }
}