using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Hotbar.UI.View
{
    public class UITutorialView : UIViewBase
    {
        public List<Sprite> explainSpriteList;

        public Image explainImage;

        public async override Task InitView() { }

        public async Task StartTutorial()
        {
            //var playCount = PlayerPrefs.GetInt("playCount");
            //playCount.LogError();

            //if (playCount == -1)
            //{
                for (int i = 0; i < explainSpriteList.Count; i++)
                {
                    explainImage.sprite = explainSpriteList[i];
                    await explainImage.DOFade(1, 1.0f).AsyncWaitForCompletion();
                    await Task.Delay(2500);
                    await explainImage.DOFade(0, 1.0f).AsyncWaitForCompletion();
                }

                //PlayerPrefs.SetInt("playCount", PlayerPrefs.GetInt("playCount") + 1);

                Close();
            //}
            //else
            //{
            //    Close();
            //}
        }
    }
}


