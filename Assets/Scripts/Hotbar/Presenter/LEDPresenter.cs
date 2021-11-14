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
            var isTrue = Random.Range(0, 100) <= 75;

            if(isTrue)
            {
                if(isLeft)
                {
                    
                    behindLED.mainTexture = trueRight;
                    frontLED.mainTexture = trueLeft;
                }
                else
                {
                    
                    behindLED.mainTexture = trueLeft;
                    frontLED.mainTexture = trueRight;
                }
            }
            else
            {
                if(isLeft)
                {
                    
                    behindLED.mainTexture = lieRight;
                    frontLED.mainTexture = lieLeft;
                }
                else
                {
                    
                    behindLED.mainTexture = lieLeft;
                    frontLED.mainTexture = lieRight;
                }
            }

            frontLED.SetFloat("floatspeed", Random.Range(0.7f, 1.5f));
        }
    }
}
