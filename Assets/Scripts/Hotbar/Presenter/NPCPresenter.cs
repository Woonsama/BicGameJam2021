using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Hotbar.Container;

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

        public async Task Behaviours()
        {
            var target = PlayerContainer.Instance.target;

            if(target != null)
            {
                while(true)
                {
                    //transform.LookAt(target.transform);
                    //transform.position = Vector3.Lerp(transform.position, target.transform.position, 3.0f);
                    await UniTask.NextFrame();
                }
            }           
        }
    }
}

