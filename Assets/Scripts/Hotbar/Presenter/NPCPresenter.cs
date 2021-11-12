using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Hotbar.Presenter
{
    public class NPCPresenter : MonoBehaviour
    {
        public enum NpcState
        {
            Stop,
            Move,
        }

        public enum NPCType
        {
            Stop,
            Yoyo,
        }

        [Header("NPC ID")]
        public int ID;

        [Header("NPC State")]
        public NpcState npcState = NpcState.Stop;

        [Header("NPC Type")]
        public NPCType npcType = NPCType.Stop;
        

        public IEnumerator StartFSM(bool isFlow)
        {
            _ = StateChange();
            StartCoroutine(npcState.ToString());

            yield return null;
        }

        #region FSM

        private IEnumerator Move()
        {
            //transform.DoMove
            yield return null;
        }

        private IEnumerator Stop()
        {
            yield return null;
        }

        #endregion

        public async Task StateChange()
        {
            while(true)
            {
                var stateChangeDelay = Random.Range(2.0f, 5.0f);
                await Task.Delay((int)(stateChangeDelay * 1000));
                await UniTask.NextFrame();
            }
        }
    }
}


