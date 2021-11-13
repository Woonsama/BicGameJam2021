using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotbar.UI.View
{
    public class UIClearView : UIViewBase
    {
        public async override Task InitView()
        {

        }
         
        public void BackToTitle() => SceneManager.LoadScene("TitleScene");
    }
}

