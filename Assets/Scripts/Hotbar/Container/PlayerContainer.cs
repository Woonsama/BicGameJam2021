using Hotbar.Pattern;
using Hotbar.Presenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotbar.Container
{
    public class PlayerContainer : SingletonMonoBase<PlayerContainer>
    {
        [Header("Player")]
        public GameObject player;

        [Header("Player Initial Transform")]
        public Transform playerInitialTransform;

        public PlayerPresenter target = null;

        public void Init()
        {
            var obj = Instantiate(player, transform);
            obj.transform.position = playerInitialTransform.position;
            var script = obj.GetComponent<PlayerPresenter>();
            target = script;
        }
    }
}


