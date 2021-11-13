using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Hotbar.Container;
using Hotbar.Model;

namespace Hotbar.Presenter
{
    public class NPCPresenter : NPCModel
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

        public async Task Comein(bool isLeft)
        {
            Vector3 target_Pos;
            Rigidbody rb = GetComponent<Rigidbody>();

            if (isLeft)
                target_Pos = new Vector3(-4f, 0f, 0f);
            else
                target_Pos = new Vector3(4f, 0f, 0f);

            SetMoveSpeed(0.1f);
            float time = 0f;

            while(true)
            {
                time += Time.deltaTime;
                transform.LookAt(target_Pos);
                transform.position += transform.forward * moveSpeed;

                if (isLeft)
                {
                    if (transform.position.x > -4)
                        break;
                }
                else
                {
                    if (transform.position.x < 4)
                        break;
                }             
                
                await UniTask.NextFrame();
            }
            
            
        }

        
    }
}

