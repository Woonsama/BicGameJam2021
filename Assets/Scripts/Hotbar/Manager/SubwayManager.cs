using Cysharp.Threading.Tasks;
using Hotbar.Pattern;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Hotbar.Manager
{
    public class SubwayManager : SingletonMonoBase<SubwayManager>
    {
        public List<string> stationList;
        public int currentStationIndex;
        public int departStationIndex;

        public void InitStation()
        {
            currentStationIndex = Random.Range(0, stationList.Count);
        }

        public async Task Start()
        {
            while (true)
            {
                await StartMove();
                await OpenDoor();
                await Wait();
                await CloseDoor();
                await UniTask.NextFrame();
            }
        }

        public async Task StartMove()
        {
            "[Subway Start Move]".LogWarning();
            var moveTime = Random.Range(20, 30);

            await Task.Delay(moveTime * 1000);
        }

        public async Task OpenDoor()
        {
            //Start Door Animation
        }

        public async Task Wait()
        {
            await Task.Delay(10000);
        }

        public async Task CloseDoor()
        {
            //Close Door Animation

        }
    }
}

