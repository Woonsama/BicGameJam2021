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
                    await Task.Yield();
                }
            }           
        }

        public async Task Left_Comein()
        {
            Vector3 target_Pos = new Vector3(5f, 0f, 0f);
            Rigidbody rb = GetComponent<Rigidbody>();
            float time = 0f;
            while(true)
            {
                time += Time.deltaTime;
                transform.LookAt(target_Pos);
                transform.position += transform.forward*0.01f;
                //transform.position = Vector3.MoveTowards(transform.position, target_Pos, Time.deltaTime*2f);
                await UniTask.NextFrame();
            }
            
            
        }

        public async Task Right_Comein()
        {
            Vector3 target_Pos = new Vector3(-5f, 0f, 0f);
        }
    }
}

