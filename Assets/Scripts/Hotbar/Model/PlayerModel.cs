using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Hotbar.Container;

namespace Hotbar.Model
{
    public class PlayerModel : MonoBehaviour
    {
        Vector3 direction;
        public float speed = 0.1f;

        public async Task Move()
        {
            //await Task.Delay(1);
            //루프가 초당 몇프레임인지 안정해져있음
            //나중에 얼마나 기다릴지를 정해줘야함
            while (true)
            {
                if (Input.GetKey(KeyCode.W))
                    direction.z = 1;
                else if (Input.GetKey(KeyCode.S))
                    direction.z = -1;
                else
                    direction.z = 0;

                if (Input.GetKey(KeyCode.A))
                    direction.x = -1;
                else if (Input.GetKey(KeyCode.D))
                    direction.x = 1;
                else
                    direction.x = 0;

                transform.position += direction.normalized * speed; //항상 일정한 속도 유지

                await UniTask.NextFrame(); //다음프레임까지 기다린다.
            }

        }


        void Start()
        {
            _ = Move(); //따로돌리고 싶으면 그냥, 기다리고 싶으면 await
            //_ = void형 반환
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                "GetMouseButtonDown1".Log();
                Player.Instance.CreateForce();
            }
        }



    }

}
