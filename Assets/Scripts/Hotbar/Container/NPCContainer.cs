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
        int MaxNpcCount = 40;

        [Header("NPC")]
        public GameObject npc;

        [Header("NPC List")]
        public List<NPCPresenter> npcList;

        [Header("Initial Generate Pos")]
        public List<Transform> initialGenerateTransformList;

        [Header("Left Door Generate Pos")]
        public List<Transform> leftDoorGenerateTransformList;

        [Header("Right Door Generate Pos")]
        public List<Transform> rightDoorGenerateTransformList;

        private int npcCreateCount = 0;
        private int npcID = 0;

        public void Init()
        {
            for (int i = 0; i < initialGenerateTransformList.Count; i++)
            {
                var script = CreateNPC();

                script.transform.position = initialGenerateTransformList[i].position;

                script.ID = ++npcID;
                ++npcCreateCount;

                _ = script.Behaviours();
            }
        }


        public async void TransfortNPC(bool isLeft, int num)
        {
            "Transfort".Log();
            if (npcCreateCount + num >= MaxNpcCount)
            {
                "TransfortNPC if¹®".Log();
                num = MaxNpcCount - npcCreateCount;
                
                if (num <= 0)
                    return;
            }
            

            if(isLeft)
            {
                for (int i = 0; i < num; i++)
                {
                    var script = CreateNPC();
                    script.transform.position = leftDoorGenerateTransformList[i].position;
                    script.ID = ++npcID;
                    ++npcCreateCount;
                    _ = script.ComeIn(isLeft);
                }
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    var script = CreateNPC();
                    script.transform.position = rightDoorGenerateTransformList[i].position;
                    script.ID = ++npcID;
                    ++npcCreateCount;
                    _ = script.ComeIn(isLeft);
                }
            }


        }

        public void SelectRandomNPC(int num)
        {
           GameObject selected;

           for(int i=0; i<num; i++)
           {
                int randomNum = Random.Range(0, MaxOutCount);
                selected = transform.GetChild(randomNum).gameObject;
                npcList.Add(selected.GetComponent<NPCPresenter>());
           }
        }

        public void SelectRandomNPC()
        {
            GameObject selected;
            "selectRandom".Log();
            int num = Random.Range(0, MaxOutCount);
            if(num + npcCreateCount >= MaxNpcCount)
            {
                num = MaxNpcCount - npcCreateCount;

                if (num <= 0)
                    return;
            }
            

            for (int i = 0; i < num; i++)
            {
                int randomNum = Random.Range(0, npcCreateCount);
                selected = transform.GetChild(randomNum).gameObject;
                npcList.Add(selected.GetComponent<NPCPresenter>());
            }
        }

        public void RemoveNPC(int id)
        {
            var target = npcList.Find(targetNPC => targetNPC.ID == id);
            npcCreateCount--;
            npcList.Remove(target);
            Destroy(target.gameObject);
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
