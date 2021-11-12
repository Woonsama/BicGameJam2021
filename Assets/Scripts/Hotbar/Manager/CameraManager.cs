using Hotbar.Pattern;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Hotbar.Container;

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
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, Player.Instance.player.transform.position + lerpPosition, lerpSmooth);
            }
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


