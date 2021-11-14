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
using Hotbar.UI;

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

        public List<UniTuple<string, string, AudioClip, bool>> stationList = new List<UniTuple<string, string, AudioClip, bool>>();
        public int currentStationIndex;
        public int departStationIndex;

        [Header("LED")]
        public LEDPresenter ledPresenter;

        private bool isLeft = false;
        public bool isClose = true;

        public bool isFinished = false;

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

        public bool DepartCheck()
        {
            $"[Current Station Index : {currentStationIndex}]".LogError();
            $"[Depart Station Index : {departStationIndex}]".LogError();


            return currentStationIndex + 1 == departStationIndex;
        }

        #region Private

        private IEnumerator StartSuywayFramework()
        {
            while (true)
            {
                if (isFinished) break;

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
            isLeft = stationList[currentStationIndex].Item4;
            yield return new WaitForSeconds(moveTime);
        }

        private IEnumerator ShowScreen()
        {
            if(currentStationIndex + 1 <= departStationIndex)
            {
                var rotText = isLeft == true ? "오른쪽" : "왼쪽";
                $"다음 역은 {stationList[currentStationIndex + 1].Item1} 입니다. 내리실 문은 {rotText} 입니다.".LogWarning();

                var length = SoundManager.Instance.PlaySE(stationList[currentStationIndex + 1].Item3);
                NPCContainer.Instance.npcList.Clear();
                NPCContainer.Instance.SelectRandomNPC(3);
                List<NPCPresenter> list = NPCContainer.Instance.npcList;
                for(int i=0; i<list.Count; i++)
                {
                    "Gather() 실행시키는 for문".Log();
                    _=list[i].Gather();
                }
                "ShowScreen".Log();
                
                yield return new WaitForSeconds(length);
            }
            else
            {
                //Open Game Failed Popup
            }

            yield return null;
        }

        private IEnumerator OpenDoor()
        {
            "[Start Door Animation]".LogWarning();

            
            isClose = false;

            //LED
            ledPresenter.ChangeLED(isLeft);

            if (isLeft)
            {
                subwayLeftDoor.SetBool("isopen", true);
            }
            else
            {
                subwayRightDoor.SetBool("isopen", true);
            }
            //내리는 로직
            if(currentStationIndex +1 == departStationIndex)
            {

            }
            else
            {
                List<NPCPresenter> list = NPCContainer.Instance.npcList;
                for (int i = 0; i < list.Count; i++)
                {
                    "GoOut실행".Log();
                    _ = list[i].GoOut(isLeft);
                }

                yield return new WaitForSeconds(3);
            }
            
            //타는 로직
            
            NPCContainer.Instance.TransfortNPC(isLeft, 8);

            yield return null;
        }

        private IEnumerator Wait()
        {
            "[Wait]".LogWarning();
            yield return new WaitForSeconds(5);
        }

        private IEnumerator WaitForClose()
        {
            yield return new WaitForSeconds(3);
            isClose = true;
        }

        private IEnumerator CloseDoor()
        {
            "[Close Door Animation]".LogWarning();

            StartCoroutine(WaitForClose());

            if (isLeft)
            {
                subwayLeftDoor.SetBool("isopen", false);
                yield return new WaitUntil(() => subwayLeftDoor.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !subwayLeftDoor.IsInTransition(0));
            }
            else
            {
                subwayRightDoor.SetBool("isopen", false);
                yield return new WaitUntil(() => subwayLeftDoor.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !subwayLeftDoor.IsInTransition(0));
            }
            currentStationIndex++;
            
            if (currentStationIndex > departStationIndex)
            {
                currentStationIndex--;
                "[게임 클리어 실패]".LogError();
                isFinished = true;
                UIManager.Instance.OpenView(UIManager.ViewType.Fail);
            }
            yield return null;
        }

        private IEnumerator StartSubwayAnimation()
        {
            var punch = new Vector3(Random.Range(-shakeRandomRange.x, shakeRandomRange.x), Random.Range(-shakeRandomRange.y, shakeRandomRange.y), Random.Range(-shakeRandomRange.z, shakeRandomRange.z));

            while(true)
            {
                map.transform.DOPunchRotation(punch, 1, 1).SetLoops(2, LoopType.Yoyo);
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

