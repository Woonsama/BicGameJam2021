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
        public GameObject forcePrefab;
        //public GameObject debug_player;

        public void CreatePlayer()
        {
            int randomNum = Random.Range(0, 4);
            Vector3 randomPos = new Vector3(randomNum, 0, randomNum);
            player = Instantiate(playerPrefab, randomPos, gameObject.transform.rotation);
        }

        public void RemovePlayer()
        {
            Destroy(player);
        }

        public void CreateForce()
        {
            Instantiate(forcePrefab, player.transform.position, player.transform.rotation);
        }
    }
}
