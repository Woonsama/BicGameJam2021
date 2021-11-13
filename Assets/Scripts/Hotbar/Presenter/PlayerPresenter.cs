using Hotbar.Container;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Hotbar.Presenter
{
    public class PlayerPresenter : MonoBehaviour
    {
        public GameObject forcePrefab;
        public GameObject dirObj;

        Vector3 direction;
        public float speed = 0.1f;
        public float smooth = 10f;

        public void Update()
        {
            Move();

            //Force
            if (Input.GetKeyDown(KeyCode.Space)) Instantiate(forcePrefab, transform.position, transform.rotation);
        }

        public void Move()
        {
            //await Task.Delay(1);
            //������ �ʴ� ������������ ������������
            //���߿� �󸶳� ��ٸ����� ���������


            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * smooth);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 180f, 0f), Time.deltaTime * smooth);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, -90f, 0f), Time.deltaTime * smooth);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 90f, 0f), Time.deltaTime * smooth);
            }


            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += transform.forward.normalized * speed;
            }
            
        }
    }
}

