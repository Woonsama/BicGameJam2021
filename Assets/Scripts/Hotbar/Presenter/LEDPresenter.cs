using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Presenter
{
    public class LEDPresenter : MonoBehaviour
    {
        public Material led;

        public Texture trueLeft;
        public Texture trueRight;
        public Texture lieLeft;
        public Texture lieRight;

        public void ChangeLED(bool isLeft)
        {
            var isTrue = Random.Range(0, 100) <= 75;

            if (isTrue)
            {
                led.mainTexture = isLeft ? trueLeft : trueRight;
            }
            else
            {
                led.mainTexture = isLeft ? lieLeft : trueRight;
            }

            led.SetFloat("floatspeed", Random.Range(0.7f, 1.5f));
        }
    }
}
