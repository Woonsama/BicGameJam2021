using Hotbar.Container;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Hotbar.Presenter
{
    public class PlayerPresenter : MonoBehaviour
    {
        public Animator animator;
        public AudioSource source;
        public AudioClip forceClip;

        public GameObject forcePrefab;
        public GameObject dirObj;

        Vector3 direction;
        public float speed = 0.1f;
        public float smooth = 10f;
        public float wallCheck_distance = 1.5f;

        public bool isMoveAvailable = true;

        RaycastHit hit;

        public void Update()
        {
            Move();

            //Force
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(forcePrefab, transform.position + new Vector3(0f, 2f, 0f), transform.rotation);
                animator.SetInteger("State", 2);
                source.clip = forceClip;
                source.Play();
            }
        }

        public void Move()
        {
            //await Task.Delay(1);
            //루프가 초당 몇프레임인지 안정해져있음
            //나중에 얼마나 기다릴지를 정해줘야함


            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * smooth);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad5))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 180f, 0f), Time.deltaTime * smooth);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, -90f, 0f), Time.deltaTime * smooth);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6))
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 90f, 0f), Time.deltaTime * smooth);
            }

            if(isMoveAvailable && (Input.GetKey(KeyCode.Keypad4)|| Input.GetKey(KeyCode.Keypad5)|| Input.GetKey(KeyCode.Keypad6)|| Input.GetKey(KeyCode.Keypad8)))
            {
                transform.position += new Vector3(transform.forward.x, 0f, transform.forward.z).normalized * speed * Time.deltaTime;
                animator.SetInteger("State", 1);
            }
            else if (isMoveAvailable && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                transform.position += new Vector3(transform.forward.x, 0f, transform.forward.z).normalized * speed * Time.deltaTime;
                animator.SetInteger("State", 1);
            }
            else
            {
                animator.SetInteger("State", 0);
            }

            isMoveAvailable = true;
            
        }
    }
}


