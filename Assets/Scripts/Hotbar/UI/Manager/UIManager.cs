using Hotbar.Pattern;
using Hotbar.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Hotbar.UI
{
    public class UIManager : SingletonMonoBase<UIManager>
    {
        public List<UniTuple<ViewType, GameObject>> viewList;

        public enum ViewType
        {
            ClearResult,
            FailResult,
            Roulette,
            InGameSetting,
        }

        public async Task<UIViewBase> OpenView(ViewType viewType)
        {
            var root = FindObjectOfType<UIRootViewBase>();
            if (root == null) return null;

            var rootParent = root.transform;


            foreach(var view in viewList)
            {
                if(view.Item1 == viewType)
                {
                    var viewBase = Instantiate(view.Item2, rootParent).GetComponent<UIViewBase>();
                    if (viewBase == null) return null;
                    await viewBase.InitView();
                    return viewBase;
                }
            }

            return null;
        }
    }
}

