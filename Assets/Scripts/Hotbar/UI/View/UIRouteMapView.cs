using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Hotbar.Manager;

namespace Hotbar.UI.View
{
    public class UIRouteMapView : UIViewBase
    {
        [Header("Background Image")]
        public Image backgroundImage;

        [Header("Route Map Image")]
        public Image routeMapImage;

        [Header("Delay Time [Milliseconds]")]
        public int delayTime;

        public async override Task InitView()
        {
            $"현재 역은 {SubwayManager.Instance.stationList[SubwayManager.Instance.currentStationIndex]} 입니다".LogWarning();
            $"목표 역은 {SubwayManager.Instance.stationList[SubwayManager.Instance.departStationIndex]} 입니다".LogWarning();
        }

        public async Task StartAnimation()
        {
            var tasks = new List<Task>();
            tasks.Add(backgroundImage.DOFade(.5f, 1.0f).AsyncWaitForCompletion());
            tasks.Add(routeMapImage.DOFade(1.0f, 1.0f).AsyncWaitForCompletion());
            await Task.WhenAll(tasks);
            tasks.Clear();

            await Task.Delay(delayTime);

            tasks.Add(backgroundImage.DOFade(0, 1.0f).AsyncWaitForCompletion());
            tasks.Add(routeMapImage.DOFade(0, 1.0f).AsyncWaitForCompletion());
            await Task.WhenAll(tasks);
            tasks.Clear();

            Close();
        }
    }
}