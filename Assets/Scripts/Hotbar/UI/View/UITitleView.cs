using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotbar.UI.View
{
    public class UITitleView : UIViewBase
    {
        public async override Task InitView()
        {
            
        }

        public void StartGame() => SceneManager.LoadScene("MainScene");
    }
}
