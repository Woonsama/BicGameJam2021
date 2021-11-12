using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hotbar.Pattern;

namespace Hotbar.Container
{
    public class Player : SingletonMonoBase<Player>
    {
        public GameObject player;
        public GameObject playerPrefab;
        public void CreatePlayer()
        {
            player = Instantiate(playerPrefab, transform);
        }

        public void RemovePlayer()
        {
            Destroy(player);
        }
    }
}
