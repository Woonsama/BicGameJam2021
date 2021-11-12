using Hotbar.Pattern;
using Hotbar.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Hotbar.Container
{
    public class NPCContainer : SingletonMonoBase<NPCContainer>
    {
        [Header("NPC")]
        public GameObject npc;

        [Header("NPC List")]
        public List<NPCPresenter> npcList;

        public void CreateNPC(int npcCount)
        {
            for(int i = 0; i < npcCount; i++)
            {
                var npc = CreateNPC();
            }
        }


        public void RemoveNPC(int id)
        {
            var target = npcList.Find(targetNPC => targetNPC.ID == id);
            npcList.Remove(target);
            Destroy(target);
        }

        #region Private

        private NPCPresenter CreateNPC() => Instantiate(npc, transform).GetComponent<NPCPresenter>();

        #endregion
    }
}
