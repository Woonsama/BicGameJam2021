using Hotbar.Pattern;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Hotbar.Container;
using Cysharp.Threading.Tasks;

namespace Hotbar.Manager
{
    public class CameraManager : SingletonMonoBase<CameraManager>
    {
        public Camera mainCamera;
        public Vector3 lerpPosition;
        public float lerpSmooth;

        private bool isFollowStart = false;

        public void Init() => isFollowStart = true;

        public void Update()
        {
            if(isFollowStart)
            {
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, PlayerContainer.Instance.target.transform.position + lerpPosition, lerpSmooth);
            }

            if (Input.GetKeyDown(KeyCode.P)) DoShake(.5f, 2.0f, .5f);
        }

        public async Task DoShake(float range, float smooth, float delay)
        {
            var initialPos = mainCamera.transform.position;
            float time = 0;

            while (time <= delay)
            {
                time += Time.deltaTime;

                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,  initialPos + new Vector3(Random.Range(-range, range), 0), smooth);
                await Task.Yield();
            }

            mainCamera.transform.position = initialPos;
        }

        public async Task DoShakePosition(float duration, float strength = 3, int vibrato = 10, float randomness = 90, bool fadeOut = true)
        {
            await mainCamera.DOShakePosition(duration, strength, vibrato, randomness, fadeOut).AsyncWaitForCompletion();
        }

        public async Task DoShakeRotate(float duration, float strength = 3, int vibrato = 10, float randomness = 90, bool fadeOut = true)
        {
            await mainCamera.DOShakeRotation(duration, strength, vibrato, randomness, fadeOut).AsyncWaitForCompletion();
        }

    }
}


