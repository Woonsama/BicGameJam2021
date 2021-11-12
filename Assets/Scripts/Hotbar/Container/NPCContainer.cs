using Hotbar.Pattern;
using Hotbar.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

namespace Hotbar.Container
{
    public class NPCContainer : SingletonMonoBase<NPCContainer>
    {
        [Header("ReadOnly")]
        public int MaxInCount = 6;
        public int MaxOutCount = 5;

        [Header("NPC")]
        public GameObject npc;

        [Header("NPC List")]
        public List<NPCPresenter> npcList;

        [Header("Initial Generate Pos")]
        public List<Transform> initialGenerateTransformList;

        private int npcCreateCount = 0;

        public void Init()
        {
            for (int i = 0; i < initialGenerateTransformList.Count; i++)
            {
                var script = CreateNPC();

                script.transform.position = initialGenerateTransformList[i].position;

                script.ID = ++npcCreateCount;

                _ = script.Behaviours();
            }
        }

        public async Task TransfortNPC()
        {

        }

        public void RemoveNPC(int id)
        {
            var target = npcList.Find(targetNPC => targetNPC.ID == id);
            npcList.Remove(target);
            Destroy(target);
        }

        #region Private

        private NPCPresenter CreateNPC()
        {
            var obj = Instantiate(npc, transform);
            var script = obj.GetComponent<NPCPresenter>();
            return script;
        }

        #endregion
    }
}
