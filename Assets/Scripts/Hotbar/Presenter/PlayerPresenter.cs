using Hotbar.Container;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Hotbar.Presenter
{
    public class PlayerPresenter : MonoBehaviour
    {
        public enum AnimState
        {
            Idle,
            Walk,
            Attack
        }
        public Animator animator;
        public AudioSource source;
        public AudioClip forceClip;

        public GameObject forcePrefab;
        public GameObject dirObj;

        Vector3 direction;
        public float speed = 0.1f;
        public float smooth = 10f;
        public float wallCheck_distance = 1.5f;

        RaycastHit hit;

        public void Update()
        {
            Move();
            Turn();
            Attack();
        }

        public void Move()
        {
            //await Task.Delay(1);
            //������ �ʴ� ������������ ������������
            //���߿� �󸶳� ��ٸ����� ���������

            if(Input.GetKey(KeyCode.Keypad4)|| Input.GetKey(KeyCode.Keypad5)|| Input.GetKey(KeyCode.Keypad6)|| Input.GetKey(KeyCode.Keypad8))
            {
                transform.position += new Vector3(transform.forward.x, 0f, transform.forward.z).normalized * speed * Time.deltaTime;
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(transform.forward.x, 0f, transform.forward.z).normalized * speed * Time.deltaTime;
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
            }
            else
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", true);
            }
        }

        private void Turn()
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8)) // 위 방향으로 회전
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * smooth);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad5)) //아래 방향으로 회전
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 180f, 0f), Time.deltaTime * smooth);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4)) // 왼쪽 방향으로 회전
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, -90f, 0f), Time.deltaTime * smooth);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6)) // 오른쪽 방향으로 회전
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 90f, 0f), Time.deltaTime * smooth);
            }
        }

        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(forcePrefab, transform.position + new Vector3(0f, 2f, 0f), transform.rotation);
                StartCoroutine(AttackAnim());
                source.clip = forceClip;
                source.Play();
            }
        }


        private IEnumerator AttackAnim()
        {
            animator.SetBool("Attack", true);
            yield return new WaitForSeconds(0.3f);
            animator.SetBool("Attack", false);
        }
    }
}


