using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace Hotbar.Presenter
{
    [RequireComponent(typeof(AudioSource))]
    public class NPCTalk : MonoBehaviour
    {
        public GameObject talkBubble;
        public Transform talkBubbleGenerateTransform;

        public List<AudioClip> clipList;
        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            StartCoroutine(Say());
        }

        public IEnumerator Say()
        {
            while(true)
            {
                var randSayTime = Random.Range(10, 20);
                yield return new WaitForSeconds(randSayTime);
                source.clip = clipList[Random.Range(0, clipList.Count)];
                source.Play();
                var obj = Instantiate(talkBubble, talkBubbleGenerateTransform);
                Destroy(obj, 2.5f);
                yield return null;
            }
        }
    }
}


