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

        public async override Task InitView() => await StartTutorial();

        public async Task StartTutorial()
        {

        }
    }
}


