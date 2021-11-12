using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hotbar.Pattern;

namespace Hotbar.Container
{
    public class Player : SingletonMonoBase<Player>
    {
        [HideInInspector]
        public GameObject player;
        public GameObject playerPrefab;
        public void CreatePlayer()
        {
            int randomNum = Random.Range(0, 4);
            Vector3 randomPos = new Vector3(randomNum, randomNum, randomNum);
            player = Instantiate(playerPrefab, randomPos, gameObject.transform.rotation);
        }

        public void RemovePlayer()
        {
            Destroy(player);
        }
    }
}
