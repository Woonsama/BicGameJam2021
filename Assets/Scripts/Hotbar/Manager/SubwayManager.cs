using Cysharp.Threading.Tasks;
using Hotbar.Pattern;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Hotbar.Utils;
using Hotbar.Presenter;
using Hotbar.Container;

namespace Hotbar.Manager
{
    public class SubwayManager : SingletonMonoBase<SubwayManager>
    {
        [Header("Map Info")]
        public GameObject map;
        public float shakeDuration;
        public Vector3 shakeRandomRange;


        [Header("Animator")]
        public Animator subwayLeftDoor;
        public Animator subwayRightDoor;

        public List<UniTuple<string, AudioClip, bool>> stationList = new List<UniTuple<string, AudioClip, bool>>();
        public int currentStationIndex;
        public int departStationIndex;

        [Header("LED")]
        public LEDPresenter ledPresenter;

        private bool isLeft = false;

        public void InitStation()
        {
            var maxDistance = 6;

            currentStationIndex = Random.Range(0, stationList.Count - maxDistance);
            departStationIndex = currentStationIndex + Random.Range(1, maxDistance);
            //currentStationIndex = Random.Range(0, stationList.Count);
        }

        public void Play()
        {
            StartCoroutine(StartSubwayAnimation());
            StartCoroutine(StartSuywayFramework());
        }

        #region Private

        private IEnumerator StartSuywayFramework()
        {
            while (true)
            {
                yield return StartMove();
                yield return ShowScreen();
                yield return OpenDoor();
                yield return Wait();
                yield return CloseDoor();
                yield return null;
            }
        }

        private IEnumerator StartMove()
        {
            "[Subway Start Move]".LogWarning();
            var moveTime = Random.Range(3, 5);

            yield return new WaitForSeconds(moveTime);
        }

        private IEnumerator ShowScreen()
        {
            if(currentStationIndex + 1 <= departStationIndex)
            {
                var rotText = isLeft == true ? "왼쪽" : "오른쪽";
                $"다음 역은 {stationList[currentStationIndex + 1].Item1} 입니다. 내리실 문은 {rotText} 입니다.".LogWarning();

                var length = SoundManager.Instance.PlaySE(stationList[currentStationIndex + 1].Item2);
                yield return new WaitForSeconds(length);
            }

            yield return null;
        }

        private IEnumerator OpenDoor()
        {
            "[Start Door Animation]".LogWarning();

            isLeft = Random.Range(0, 2) == 0;

            //LED
            ledPresenter.ChangeLED(isLeft);

            if (isLeft)
            {
                subwayLeftDoor.SetBool("isopen", true);
                NPCContainer.Instance.SetGenerateTransformList(true, 8);
                NPCContainer.Instance.TransfortNPC(true, 8);
                "left".Log();
            }
            else
            {
                subwayRightDoor.SetBool("isopen", true);
                NPCContainer.Instance.SetGenerateTransformList(false, 8);
                NPCContainer.Instance.TransfortNPC(false, 8);
                "right".Log();
            }

            yield return null;
        }

        private IEnumerator Wait()
        {
            "[Wait]".LogWarning();
            yield return new WaitForSeconds(3);
        }

        private IEnumerator CloseDoor()
        {
            "[Close Door Animation]".LogWarning();

            if (isLeft)
            {
                subwayLeftDoor.SetBool("isopen", false);
            }
            else
            {
                subwayRightDoor.SetBool("isopen", false);
            }

            currentStationIndex++;

            yield return null;
        }

        private IEnumerator StartSubwayAnimation()
        {
            while(true)
            {
                //yield return ShakeMap(shakeDuration, shakeRandomRange);
                map.transform.DOPunchRotation(shakeRandomRange, 1, 1).SetLoops(2, LoopType.Yoyo);
                yield return new WaitForSeconds(1.0f);
            }
        }

        private IEnumerator ShakeMap(float duration, Vector3 randomness)
        {
            float t = 0;
            //var mapInitialPosition = map.transform.position;
            var mapInitialRoatation = map.transform.rotation;

            while (t <= duration)
            {
                t += Time.deltaTime;

                //map.transform.position = Vector3.Lerp(map.transform.position, map.transform.position + new Vector3(Random.Range(-randomness.x, randomness.x), Random.Range(-randomness.y, randomness.y), Random.Range(-randomness.z, randomness.z)), 1.0f);
                map.transform.rotation = Quaternion.Euler(Vector3.Lerp(map.transform.rotation.eulerAngles, map.transform.rotation.eulerAngles + new Vector3(Random.Range(-randomness.x, randomness.x), Random.Range(-randomness.y, randomness.y), Random.Range(-randomness.z, randomness.z)), 1.0f));
                yield return null;
            }


            //map.transform.position = mapInitialPosition;
            map.transform.rotation = mapInitialRoatation;
        }

        #endregion
    }
}

