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
        public Animator enemy_anim;
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

        public async Task ComeIn(bool isLeft)
        {
            Vector3 target_Pos;
            Rigidbody rb = GetComponent<Rigidbody>();

            if (isLeft)
                target_Pos = new Vector3(-4f, 0f, 0f);
            else
                target_Pos = new Vector3(4f, 0f, 0f);

            SetMoveSpeed(3f);
            float time = 0f;

            GetComponent<NPCPresenter>().enemy_anim.SetBool("isWalk", true);
            while (true)
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
            GetComponent<NPCPresenter>().enemy_anim.SetBool("isWalk", false);
        }

        public async Task Gather()
        {
            "Gather".Log();
            Vector3 target_Pos = new Vector3(transform.position.x, 0f, 0f);
            float time = 0f;
            int frequency = Random.Range(2, 4);

            SetMoveSpeed(3f);
            GetComponent<NPCPresenter>().enemy_anim.SetBool("isWalk", true);
            while (true)
            {
                if (transform.position.z < 2f)
                {
                    "NPC 중앙집결 Break".Log();
                    break;
                }
                transform.LookAt(target_Pos);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                time += Time.deltaTime;
                "이동".Log();
                await UniTask.NextFrame();
            }
            GetComponent<NPCPresenter>().enemy_anim.SetBool("isWalk", false);

        }

        public async Task GoOut(bool isLeft)
        {
            Vector3 target_Pos;

            if (isLeft)
                target_Pos = new Vector3(-6f, 0f, 0f);
            else
                target_Pos = new Vector3(6f, 0f, 0f);

            SetMoveSpeed(3f);
            float time = 0f;

            GetComponent<NPCPresenter>().enemy_anim.SetBool("isWalk", true);
            while (true)
            {
                time += Time.deltaTime;
                transform.LookAt(target_Pos);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

                if (isLeft)
                {
                    if (transform.position.x < -5.5)
                        NPCContainer.Instance.RemoveNPC(GetComponent<NPCPresenter>().ID);
                }
                else
                {
                    if (transform.position.x > 5.5)
                        NPCContainer.Instance.RemoveNPC(GetComponent<NPCPresenter>().ID);
                }

                await UniTask.NextFrame();
            }
        }

        public async Task CheckInside()
        {
            while (true)
            {
                if(transform.position.x < 5 || transform.position.x > -5)
                {
                    isInside = false;
                    break;
                }
                await UniTask.NextFrame();
            }
        }




    }
}

