using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Hotbar.UI
{
    public class UIViewBase : MonoBehaviour
    {
        public virtual async Task InitView()
        {
            
        }

        public virtual async Task UpdateView()
        {
            
        }

        //Temp
        public virtual void Close() => Destroy(gameObject);
    }
}
