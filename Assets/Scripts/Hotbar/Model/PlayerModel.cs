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
            //������ �ʴ� ������������ ������������
            //���߿� �󸶳� ��ٸ����� ���������
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

                transform.position += direction.normalized * speed; //�׻� ������ �ӵ� ����

                await UniTask.NextFrame(); //���������ӱ��� ��ٸ���.
            }

        }


        void Start()
        {
            _ = Move(); //���ε����� ������ �׳�, ��ٸ��� ������ await
            //_ = void�� ��ȯ
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
