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

            SetMoveSpeed(3f);
            float time = 0f;

            while(true)
            {
                time += Time.deltaTime;
                transform.LookAt(target_Pos);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

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

        public async Task Gather()
        {
            Vector3 target_Pos = new Vector3(0f, 0f, 0f);
            float time = 0f;
            int frequency = Random.Range(2, 4);

            while(true)
            {
                if(time > frequency)
                {
                    time = 0f;
                    if (Vector3.Distance(transform.position, new Vector3(0f, 0f, 0f)) < 2f)
                        break;
                    else
                        frequency = Random.Range(2, 4);
                }
                transform.LookAt(target_Pos);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                time += Time.deltaTime;
            }
            
        }

        public async Task Goout(bool left)
        {
            
        }

        

        
    }
}

