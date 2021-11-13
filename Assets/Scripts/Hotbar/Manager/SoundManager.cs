using Hotbar.Pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Manager
{
    public class SoundManager : SingletonMonoBase<SoundManager>
    {
        [Header("SE")]
        public AudioSource se;

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


