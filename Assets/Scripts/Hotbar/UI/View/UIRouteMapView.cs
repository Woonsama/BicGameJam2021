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
        public Text currentStationKorText;
        public Text currentStationEnText;

        public Text departStationKorText;
        public Text departStationEnText;

        public async override Task InitView()
        {
            currentStationKorText.text = SubwayManager.Instance.stationList[SubwayManager.Instance.currentStationIndex].Item1;
            currentStationEnText.text = SubwayManager.Instance.stationList[SubwayManager.Instance.currentStationIndex].Item2;

            departStationKorText.text = SubwayManager.Instance.stationList[SubwayManager.Instance.departStationIndex].Item1;
            departStationEnText.text = SubwayManager.Instance.stationList[SubwayManager.Instance.departStationIndex].Item2;

            $"현재 역은 {SubwayManager.Instance.stationList[SubwayManager.Instance.currentStationIndex].Item1} 입니다".LogWarning();
            $"목표 역은 {SubwayManager.Instance.stationList[SubwayManager.Instance.departStationIndex].Item1} 입니다".LogWarning();
        }
    }
}