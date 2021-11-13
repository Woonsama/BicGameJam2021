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

        [Header("Left Door Generate Pos")]
        public List<Transform> leftDoorGenerateTransformList;

        [Header("Right Door Generate Pos")]
        public List<Transform> rightDoorGenerateTransformList;

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

        public void SetGenerateTransformList(bool isLeft, int num)
        {
            List<Transform> List;
            GameObject cur;
            GameObject standard = new GameObject();
            
            float unitNum_x;
            float unitNum_z;
            int checkingNum_x;

            if(isLeft)
            {
                List = leftDoorGenerateTransformList;
                standard.transform.position = new Vector3(-6f, 0f, 0f);
                unitNum_x = -1.0f;
            }
            else
            {
                List = rightDoorGenerateTransformList;
                standard.transform.position = new Vector3(6f, 0f, 0f);
                unitNum_x = 1.0f;
            }

            cur = standard;

            for (int i =0; i<num; i++)
            {
                if (i % 2 == 0)
                {
                    unitNum_z = 1.5f;
                    checkingNum_x = i/2;
                }
                else
                {
                    unitNum_z = -1.5f;
                }
                checkingNum_x = i / 2;
                Debug.Log(checkingNum_x);

                cur.transform.position = new Vector3(i * unitNum_x, 0f, unitNum_z) + standard.transform.position;
                
                
                List.Add(cur.transform);
                Debug.Log(cur.transform.position);
            }
        }

        public async void TransfortNPC(bool isLeft, int num)
        {
            if(isLeft)
            {
                for (int i = 0; i < num; i++)
                {
                    var script = CreateNPC();
                    script.transform.position = leftDoorGenerateTransformList[i].position;
                    script.ID = ++npcCreateCount;
                    _ = script.Comein(isLeft);
                }
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    var script = CreateNPC();
                    script.transform.position = rightDoorGenerateTransformList[i].position;
                    script.ID = ++npcCreateCount;
                    _ = script.Comein(isLeft);
                }
            }


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
