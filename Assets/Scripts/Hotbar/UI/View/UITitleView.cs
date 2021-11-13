using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hotbar.UI.View
{
    public class UITitleView : MonoBehaviour
    {
        public Animation titleAnim;

        public async void StartGame()
        {
            "[Game Start]".LogError();

            titleAnim.clip = titleAnim.GetClip("title_end");
            titleAnim.Play();

            await UniTask.WaitUntil(() => titleAnim.isPlaying == false); 
            SceneManager.LoadScene("MainScene");
        }
    }
}
