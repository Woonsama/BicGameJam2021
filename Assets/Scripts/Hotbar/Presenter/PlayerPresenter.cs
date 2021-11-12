using Hotbar.Container;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Presenter
{
    public class PlayerPresenter : MonoBehaviour
    {
        public GameObject forcePrefab;

        Vector3 direction;
        public float speed = 0.1f;

        public void Update()
        {
            Move();

            //Force
            //if (Input.GetMouseButtonDown(0)) Instantiate(forcePrefab, transform);
        }

        public void Move()
        {
            //await Task.Delay(1);
            //������ �ʴ� ������������ ������������
            //���߿� �󸶳� ��ٸ����� ���������
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
        }
    }
}


