using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Presenter
{
    public class LEDPresenter : MonoBehaviour
    {
        public Material frontLED;
        public Material behindLED;

        public Texture trueLeft;
        public Texture trueRight;
        public Texture lieLeft;
        public Texture lieRight;

        public void ChangeLED(bool isLeft)
        {
            var isTrue = Random.Range(0, 100) <= 80;

            if(isTrue)
            {
                if(isLeft)
                {
                    frontLED.mainTexture = trueLeft;
                    behindLED.mainTexture = trueRight;
                }
                else
                {
                    frontLED.mainTexture = trueRight;
                    behindLED.mainTexture = trueLeft;
                }
            }
            else
            {
                if(isLeft)
                {
                    frontLED.mainTexture = lieLeft;
                    behindLED.mainTexture = lieRight;
                }
                else
                {
                    frontLED.mainTexture = lieRight;
                    behindLED.mainTexture = lieLeft;
                }
            }

            frontLED.SetFloat("floatspeed", Random.Range(0.7f, 2.0f));
        }
    }
}
