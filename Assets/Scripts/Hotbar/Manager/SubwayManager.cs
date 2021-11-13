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

        public async Task Play()
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
            var moveTime = Random.Range(3, 5);

            await Task.Delay(moveTime * 1000);
        }

        public async Task OpenDoor()
        {
            "[Start Door Animation]".LogWarning();
        }

        public async Task Wait()
        {
            "[Wait]".LogWarning();
            await Task.Delay(3000);
        }

        public async Task CloseDoor()
        {
            "[Close Door Animation]".LogWarning();
        }
    }
}

