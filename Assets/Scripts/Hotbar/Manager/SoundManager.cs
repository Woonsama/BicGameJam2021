using Hotbar.Pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Manager
{
    public class SoundManager : SingletonMonoBase<SoundManager>
    {
        [Header("BGM")]
        public AudioSource bgm;

        [Header("SE")]
        public AudioSource se;

        public void SetBGMVolume(float volume)
        {
            bgm.volume = volume;
        }

        public void SetSEVolume(float volume)
        {
            se.volume = volume;
        }

        public float PlaySE(AudioClip clip, float volume = .5f)
        {
            if(clip != null)
            {
                se.clip = clip;
                se.volume = volume;
                se.Play();
                return se.clip.length;
            }
            return 0;
        }
    }
}


