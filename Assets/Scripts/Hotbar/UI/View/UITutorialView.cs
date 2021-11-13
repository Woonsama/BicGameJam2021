using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Hotbar.UI.View
{
    public class UITutorialView : UIViewBase
    {
        public List<Sprite> explainSpriteList;

        public async override Task InitView() => await StartTutorial();

        public async Task StartTutorial()
        {

        }
    }
}


